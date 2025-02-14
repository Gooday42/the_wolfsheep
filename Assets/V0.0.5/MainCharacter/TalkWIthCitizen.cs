using UnityEngine;
using UnityEngine.InputSystem;

public class TalkWithCitizen : MonoBehaviour
{
    public Citizen citizenToTalk;
    public GameObject DialogWindow;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Citizen>(out Citizen citizen))
        {
            citizenToTalk = citizen;
        }
    }

    private void Update() 
    {
        if(citizenToTalk != null)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                DisplayCitizenDialog();
                GetComponent<MoveWithKeyboard>().enabled =false;
            }
        }
    }
    public void DisplayCitizenDialog()
    {
        DialogWindow.SetActive(true);
    }

}
