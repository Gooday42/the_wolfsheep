using System;
using System.Collections.Generic;
using UnityEngine;

public class SimplyCitizenRoutine : MonoBehaviour
{
    public bool IsLooping = false;

   [SerializeField] public List<Vector3> whereToGo = new();

    private int currentPos = 0;
    private SimplyMovent Legs;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if(GetComponent<SimplyMovent>() ==null) gameObject.AddComponent<SimplyMovent>();
        Legs = GetComponent<SimplyMovent>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if(!Legs.IsMoving && !FindAnyObjectByType<CitizenInteraction3D>().adultsAreTalking)
        {
             if(IsLooping && currentPos >= whereToGo.Count){
                 currentPos = 0;
                 Debug.Log("Looping~");
             }
            currentPos = Math.Clamp(currentPos,0,whereToGo.Count-1);   

            Legs.MoveTo(whereToGo[currentPos]);
            currentPos++;
        }
    }

}
