using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class MoonEvents : MonoBehaviour
{
    [SerializedDictionary("Prefab", "frecuency(%)")]
    public SerializedDictionary<GameObject, float> Moons = new();

    public void GetMoon(int Probability)
    {
        if(Dice.D100(Probability))
        {

            ActiveMoon();

        }
    }

    void  ActiveMoon()
    {
        GameObject moon = Moons.ElementAt(UnityEngine.Random.Range(0,Moons.Count)).Key;
        float Probability = Moons.ElementAt(UnityEngine.Random.Range(0,Moons.Count)).Value;

        
    }

}
