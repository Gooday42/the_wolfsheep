using UnityEngine;
using UnityEngine.UI;


public class ButtonAndKeyBinding : MonoBehaviour
{
    public KeyCode key = KeyCode.Escape;
    private void Update() {
        
        if(Input.GetKeyDown(key))
        {
            Debug.Log($"{key} pressed");
            GetComponent<Button>().onClick.Invoke();
        }
   }
}
