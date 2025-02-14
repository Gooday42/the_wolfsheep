using UnityEngine;

public class MoveWithKeyboard : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow keys

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude >= 0.1f)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}
