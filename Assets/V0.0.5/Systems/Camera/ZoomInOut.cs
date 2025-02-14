using UnityEngine;
using Cinemachine;

public class ZoomInOut : MonoBehaviour
{

    public static ZoomInOut instance;
    public CinemachineVirtualCamera cinemachineCamera;
    public float targetFOV;
    
    public float zoomSpeed = 10f;
    public float minFOV = 20f;
    public float maxFOV = 60f;

/// <summary>
/// Awake is called when the script instance is being loaded.
/// </summary>
    void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }    
    }

    void Start()
    {
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        targetFOV = cinemachineCamera.m_Lens.FieldOfView;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        //if (scroll != 0)
        //{
            targetFOV -= scroll * zoomSpeed;
            targetFOV = Mathf.Clamp(targetFOV, minFOV, maxFOV);
            cinemachineCamera.m_Lens.FieldOfView = targetFOV;
        //}
    }
}

