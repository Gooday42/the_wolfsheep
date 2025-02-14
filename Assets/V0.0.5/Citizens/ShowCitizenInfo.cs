using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowCitizenInfo : MonoBehaviour
{
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    /// 
    public GameObject image;
    public Citizen thisGuy;
    public void ShowInfo()
    {
        GetComponentInChildren<TMP_Text>().text = thisGuy.name;
        image.GetComponent<Image>().sprite = thisGuy.GetComponent<SpriteRenderer>().sprite;
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        ShowInfo();
    }
}
