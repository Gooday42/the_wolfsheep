using Unity.VisualScripting;
using UnityEngine;

public class Witch : MonoBehaviour
{
   public Sprite witchHouse;

   /// <summary>
   /// Awake is called when the script instance is being loaded.
   /// </summary>

   private void OnTransformParentChanged() {
    if(transform.parent.gameObject.GetComponent<SpriteRenderer>() != null){
        transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = witchHouse;
        transform.parent.gameObject.AddComponent<Witch>();
       }
   }


}
