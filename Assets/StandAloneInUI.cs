using UnityEngine;
using UnityEngine.UI; // Include this if you're working with UI elements

public class StandAloneInUI : MonoBehaviour
{
    // Reference to all UI elements you want to manage
    public GameObject[] uiElements;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        DeactivateOtherElements();
    }
    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        ReactivateElements();
    }

    private void DeactivateOtherElements()
    {
        foreach (GameObject element in uiElements)
        {
            if (element != gameObject) // Ensure we don't deactivate ourselves
            {
                element.SetActive(false);
            }
        }
    }

    private void ReactivateElements()
    {
        foreach (GameObject element in uiElements)
        {
            element.SetActive(true);
        }
    }
}