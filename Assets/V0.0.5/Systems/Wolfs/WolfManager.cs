 using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WolfManager : MonoBehaviour
{

    public static WolfManager instance;
    public List<Citizen> AllWolfs;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        CreateWolves();
    }
    public void CreateWolves()
    {
        if (AllWolfs.Count > 0) return; // Prevents re-creating wolves

        CitizenManager citizenManager = GetComponent<CitizenManager>(); // Cache the component
        List<Citizen> availableCitizens = new List<Citizen>(citizenManager.AllCitizens); // Copy citizens list

        int totalWolves = Mathf.Min(GameManager.TotalWolfs, availableCitizens.Count); // Prevent out-of-bounds issues

        for (int i = 0; i < totalWolves; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, availableCitizens.Count);
            Citizen selectedCitizen = availableCitizens[randomIndex];

            CreateWolf(selectedCitizen);
            
            AllWolfs.Add(selectedCitizen);
            availableCitizens.RemoveAt(randomIndex); // Ensures no duplicate selection
        }
    }
    public bool CreateWolf(Citizen citizen)
    {
        if(AllWolfs.Contains(citizen))
        { 
        Debug.LogWarning("Already A Wolf"); return false;
        }else
        {
        AllWolfs.Add(citizen);
        citizen.IsWolf = true;
        return true;
        }

    }
    public void KillCitizen(Citizen citizen)
    {
        citizen.OnDeath.Invoke();
        FindAnyObjectByType<CitizenManager>().LivingCitizens.Remove(citizen);
        FindAnyObjectByType<CitizenManager>().DeadCitizens.Add(citizen);
    }
    public void HuntCitizen(Citizen citizen)
    {
        int votes = 0;
        
        CitizenManager citizenManager = GetComponent<CitizenManager>(); // Cache the component
        List<Citizen> livingWolves = AllWolfs.Where(wolf => citizenManager.LivingCitizens.Contains(wolf)).ToList(); // Get all living wolves

        foreach (Citizen wolf in livingWolves)
        {
            if (citizen.GetValue() >= 50)
            {
                votes++;
            }
        }

        // Check if votes are at least 50% or more of living wolves
        if (votes >= Mathf.CeilToInt(livingWolves.Count / 2f)) 
        {
            KillCitizen(citizen);
        }
    }

}
