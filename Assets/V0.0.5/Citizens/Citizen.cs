using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Citizen : MonoBehaviour
{
    public string Name;
    public Personality personality;
    public bool IsWolf;

    public Dictionary<Citizen,int> Neighbours;

    public List<GameObject> Roles;

    public UnityEvent OnDeath;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        personality = GetRandomEnumValue<Personality>();

        Name = "Joe Down";
    }

    public GameObject[] GetNeighbours()
    {
        return Neighbours.Keys.Select(key => key.gameObject).ToArray();
    }

    public enum Personality
    {
        Nervous,
        Sharp,
        Slothful,
        Chaotic,
        trustful

    }

    public T GetRandomEnumValue<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        }
    public int GetValue()
    {
       return GetComponent<CitizenManager>().GetRandomValue(personality);
    }
}
