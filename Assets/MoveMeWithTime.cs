using UnityEngine;

public class MoveMeWithTime : MonoBehaviour
{
    public float CurrentAngle = 0; // Angle of the light
    public Light SunLight;         // Reference to the Light component (e.g., Directional Light)
    public float MaxIntensity = 5f; // Maximum intensity of the light
    public float MinIntensity = 0.1f; // Minimum intensity (e.g., at sunrise/sunset)

    void Update()
    {
    
    }
}
