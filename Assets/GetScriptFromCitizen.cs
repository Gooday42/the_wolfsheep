using UnityEngine;
using UnityEngine.UI;

public class GetScriptFromCitizen : MonoBehaviour
{
    private Sprite sprite;
   void Start()
   {
           GetComponent<Image>().sprite = GetComponent<TalkWithOneCitizen>().talkingWith.GetComponent<SpriteRenderer>().sprite;
   }
}
