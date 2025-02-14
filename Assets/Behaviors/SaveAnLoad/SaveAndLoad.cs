using UnityEngine;
using System.Collections.Generic;
public class SaveAndLoad : MonoBehaviour
{
    public void SaveGame()
    {
        CitizenDataCollection dataCollection = new();

        // Find all citizens and save their data
        Citizen[] allCitizens = FindObjectsByType<Citizen>(FindObjectsSortMode.None);
        foreach (Citizen citizen in allCitizens)
        {
            CitizenData data = new CitizenData
            {
                position = new float[]
                {
                    citizen.gameObject.transform.position.x,
                    citizen.gameObject.transform.position.y,
                    citizen.gameObject.transform.position.z
                },
                //citizen = citizen.SaveToString()
            };
            dataCollection.citizens.Add(data);
        }

        // Save the number of nights passed
        dataCollection.PassedNights = DaysManager.Nights;

        // Serialize the data to JSON and save to PlayerPrefs
        string json = JsonUtility.ToJson(dataCollection);
        PlayerPrefs.SetString("GameSaveData", json);
        PlayerPrefs.Save();

        Debug.Log("Game saved successfully!");
    }

    public void LoadGame()
    {
        if (!PlayerPrefs.HasKey("GameSaveData"))
        {
            Debug.LogWarning("No save data found!");
            return;
        }

        // Load the JSON string from PlayerPrefs
        string json = PlayerPrefs.GetString("GameSaveData");
        CitizenDataCollection dataCollection = JsonUtility.FromJson<CitizenDataCollection>(json);

        // Restore citizens
        foreach (CitizenData data in dataCollection.citizens)
        {
            Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
            Citizen citizen = InstantiateCitizenAtPosition(position);
            //citizen.LoadFromString(data.citizen);
        }

        // Restore the number of nights passed
        DaysManager.Nights = dataCollection.PassedNights;

        Debug.Log("Game loaded successfully!");
    }

    private Citizen InstantiateCitizenAtPosition(Vector3 position)
    {
        // Assume a citizen prefab exists and is named "CitizenPrefab"
        GameObject citizenPrefab = Resources.Load<GameObject>("CitizenPrefab");
        if (citizenPrefab == null)
        {
            Debug.LogError("CitizenPrefab not found in Resources folder!");
            return null;
        }

        GameObject citizenObject = Instantiate(citizenPrefab, position, Quaternion.identity);
        return citizenObject.GetComponent<Citizen>();
    }
}

// Helper classes for saving and loading data
[System.Serializable]
public class CitizenData
{
    public float[] position; // [x, y, z] coordinates
    public string citizen;   // Serialized citizen data
}

[System.Serializable]
public class CitizenDataCollection
{
    public int PassedNights;              // Number of nights passed
    public List<CitizenData> citizens = new(); // List of all saved citizens
}
