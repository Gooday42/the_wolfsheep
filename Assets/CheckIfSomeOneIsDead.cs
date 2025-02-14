using AYellowpaper.SerializedCollections;
using UnityEngine;

public class CheckIfSomeOneIsDead : MonoBehaviour
{   

    [SerializedDictionary("Citizen","Live Status")]
    public static SerializedDictionary<Citizen, bool> KilledCitizen;


}
