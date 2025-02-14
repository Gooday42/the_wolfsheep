using UnityEngine;

public class Hunter : MonoBehaviour
{
   public Sprite hunterHouse;

   /// Called when the parent property of the transform of the GameObject has changed.
   /// </summary>
   void OnTransformParentChanged()
   {
       if(transform.parent.gameObject.GetComponent<SpriteRenderer>() != null){
        transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = hunterHouse;
        transform.parent.gameObject.AddComponent<Hunter>();

       }
   }


}
