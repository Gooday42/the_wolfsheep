using UnityEngine;

public class DisplayThisOnTrigger : MonoBehaviour
{

    [SerializeField] public GameObject DisplayThis;
    public void Show()
    {
        DisplayThis.SetActive(true);
    }

    public void Hide()
    {
        DisplayThis.SetActive(false);
    }
}
