using UnityEngine;

public class TalkingRoutine : MonoBehaviour
{
    private Animator virtualCameraAnimator;

    void Awake()
    {
        // Cache the reference to the Animator
        GameObject virtualCamera = GameObject.Find("Virtual Camera");
        if (virtualCamera != null)
        {
            virtualCameraAnimator = virtualCamera.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Virtual Camera not found! Ensure a GameObject named 'Virtual Camera' exists in the scene.");
        }
    }

    public void startTalking()
    {
        if (virtualCameraAnimator != null)
        {
            virtualCameraAnimator.speed = 1;
            virtualCameraAnimator.SetTrigger("zoomIt");
        }
    }

    public void StopTalking()
    {
        if (virtualCameraAnimator != null)
        {
            virtualCameraAnimator.speed = -1;
            virtualCameraAnimator.SetTrigger("zoomIt");
        }
    }
}
