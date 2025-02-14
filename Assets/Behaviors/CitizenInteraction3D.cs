using System.Collections;
using Cinemachine;
using UnityEngine;

public class CitizenInteraction3D : MonoBehaviour
{
    private bool isColliding = false;
    public bool adultsAreTalking = false;
    public bool zoomed = false;
    public KeyCode interactKey = KeyCode.E;
    public float zoomDuration = 0.5f; // Adjustable time for the zoom transition

    public GameObject CurrentCitizen;

    private MoveWithKeyboard simplyMovent;
    private TalkingRoutine talkingRoutine;

    void Awake()
    {
        simplyMovent = GetComponent<MoveWithKeyboard>();
        talkingRoutine = GetComponent<TalkingRoutine>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Citizen>() != null && CurrentCitizen == null)
        {
            CurrentCitizen = other.gameObject;
            CurrentCitizen.GetComponent<DisplayThisOnTrigger>().Show();
            adultsAreTalking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CurrentCitizen == other.gameObject)
        {
            CurrentCitizen.GetComponent<DisplayThisOnTrigger>().Hide();
            CurrentCitizen = null;
            adultsAreTalking = false;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            
            Debug.Log("interacting");
            if (adultsAreTalking)
            {
                
            Debug.Log("And is close");
                if (!zoomed)
                {
                    
                    Debug.Log("zooming");    
                    StartTalking();
                }
                else
                {
                    StopTalking();
                }
            }
        }
    }

    private void StartTalking()
    {
        if (talkingRoutine != null && simplyMovent != null)
        {
            Debug.Log("zoomIn");
            talkingRoutine.startTalking();
            simplyMovent.enabled = false;
            zoomed = true;
        }
    }

    private void StopTalking()
    {
        if (talkingRoutine != null && simplyMovent != null)
        {
            Debug.Log("zoomOut");
            talkingRoutine.StopTalking();
            simplyMovent.enabled = true;
            zoomed = false;
        }
    }
}
