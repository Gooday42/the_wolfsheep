using UnityEngine;

public class CloseThis_UI : MonoBehaviour
{
    
    [SerializeField] public GameObject thisThing;

    public void CloseIt(){
        thisThing.SetActive(false);
    }
}
