using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CitizenManager : MonoBehaviour
{
    public static CitizenManager instance;
    
    [Range(-1.0f, 1.0f)]
    public float TownTrust = 0; //     public List<Citizen> AllCitienz;
    public List<Citizen> DeadCitizens;
    public List<Citizen> LivingCitizens;
    
    public List<Citizen> AllCitizens;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        AssignRelations();
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if(TownTrust <= -1.0)
        {
           //GameOver D:
        }
    }
    public void AcuseCitizen(Citizen citizen)
    {
        if(citizen.IsWolf)
        {
            TownTrust += 0.5f;
        }else
        {
            TownTrust -= 0.5f;
        }
    }
    public void AssignRelations()
    {
        List<Citizen> TemporalNeighbours;

        TemporalNeighbours = AllCitizens;

        foreach (Citizen citizen in TemporalNeighbours)
        {
            foreach (Citizen neigbours in TemporalNeighbours)
            {
                if(citizen !=  neigbours)
                {
                    citizen.Neighbours.Add(neigbours, GetRandomValue(citizen.personality));
                }
            }
            TemporalNeighbours.Remove(citizen);
        }

    }
   public int GetRandomValue(Citizen.Personality personality)
    {
        float initalRandomValue = UnityEngine.Random.Range(0.0f, 100.0f);

        switch (personality)
        {
            case Citizen.Personality.Chaotic:
                return (int)initalRandomValue;

            case Citizen.Personality.Nervous:
                // Introduce unpredictability based on game state
                float chaosFactor = (UnityEngine.Random.value > 0.5f) ? 1 : -1;
                float finalValue = initalRandomValue + chaosFactor * DeadCitizens.Count * TownTrust * GameManager.PassedNights;
                return (int)Mathf.Clamp(finalValue, 0, 100);

            case Citizen.Personality.Sharp:
                // Smarter individuals have more consistent values
                float sharpValue = initalRandomValue + Mathf.Pow(initalRandomValue, Mathf.Clamp(TownTrust, 1, 3));
                return (int)Mathf.Clamp(sharpValue, 0, 100);

            case Citizen.Personality.Slothful:
                // Slow growth over time
                float lazyValue = (initalRandomValue * 0.10f) + GameManager.PassedNights * 5;
                return (int)Mathf.Clamp(lazyValue, 0, 100);

            case Citizen.Personality.trustful:
                // Trustful individuals have values that decrease over time
                float coolValue = 100 - (initalRandomValue + Mathf.Pow(GameManager.PassedNights, Mathf.Clamp(DeadCitizens.Count, 1, 10)));
                return (int)Mathf.Clamp(coolValue, 0, 100);

            default:
                return (int)initalRandomValue;
        }
    }
}
