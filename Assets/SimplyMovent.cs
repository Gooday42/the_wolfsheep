using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplyMovent : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    public bool IsMoving = false;
    private Vector3 FinalPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveTo(Vector3 finalPosition)
    {
        if(finalPosition == null && FinalPosition !=null) finalPosition = FinalPosition;
        if(FinalPosition != finalPosition) FinalPosition = finalPosition;
        StartCoroutine(MoveRoutine(finalPosition));
    }
   public void MoveTo()
    {
       StartCoroutine(MoveRoutine(FinalPosition));
    }
    public void StopMe()
    {
        StopAllCoroutines();
        IsMoving = false;
    }

    private System.Collections.IEnumerator MoveRoutine(Vector3 finalPosition)
    {
        finalPosition.y = rb.position.y; // Ensure movement stays in the XZ plane

        while (Vector3.Distance(rb.position, finalPosition) > 0.1f)
        {
            IsMoving = true;
            
            Debug.Log("Moving");

            Vector3 direction = (finalPosition - rb.position).normalized;
            Vector3 newPosition = rb.position + direction * speed * Time.deltaTime;
            rb.MovePosition(newPosition);
            yield return null;
        }

        rb.MovePosition(finalPosition); // Snap to the final position
        
        Debug.Log("Stop");
        IsMoving = false;
        
    }


}
