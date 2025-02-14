using TMPro;
using UnityEngine;

public class NightDisplay : MonoBehaviour
{
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GetComponent<TMP_Text>().text = 
        $"## wolfs lefts \n {DaysManager.Nights} Nights has passed";
    }
}
