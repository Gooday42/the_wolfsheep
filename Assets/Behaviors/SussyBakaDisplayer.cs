using UnityEngine;
using AYellowpaper.SerializedCollections;
using TMPro;

public class SussyBakaDisplayer : MonoBehaviour
{
    public void displaySussy(SerializedDictionary<GameObject, int> dicc)
    {
        int i = 0;
        foreach (var kvp in dicc)
        {
            GameObject neighbor = kvp.Key;
            int suspicionLevel = kvp.Value;
            
            GameObject container = transform.GetChild(i).gameObject;

            string totalText = $"I have a {calculateSussiness(suspicionLevel)} of {neighbor.name}";

           // totalText += calculateSussiness(suspicionLevel); 
            container.GetComponentInChildren<TMP_Text>().text = totalText;

            i++;
        }
    }

    public void ChangeSprite(Sprite cara)
    {
        
        GameObject.Find("CitizenPanel/Face").GetComponent<SpriteRenderer>().sprite =cara;
    }
string calculateSussiness(int lvl)
{
    return lvl switch
    {
        <= 20 => "Very Low suspicion",
        <= 40 => "Low suspicion",
        <= 60 => "Moderate suspicion",
        <= 80 => "High suspicion",
        <= 100 => "Very High suspicion",
        _ => "Extreme suspicion" // For levels above 50
    };
}

}
