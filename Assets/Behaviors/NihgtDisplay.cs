using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NihgtDisplay : MonoBehaviour
{
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        GetComponent<TMP_Text>().text = $"A night falls, the moon rises and the wolfs awake \n \n {DaysManager.Nights} nights has passed ";
    }
}
