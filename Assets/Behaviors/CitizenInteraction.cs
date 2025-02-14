using UnityEngine;

public class CitizenInteraction : MonoBehaviour
{
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        GetComponent<Citizen>().GetNeighbours();

        FindAnyObjectByType<DisplayINfo>().showPanel();

        //FindAnyObjectByType<SussyBakaDisplayer>().displaySussy(GetComponent<Citizen>().neighbourSusLeve());
        FindAnyObjectByType<SussyBakaDisplayer>().ChangeSprite(GetComponent<SpriteRenderer>().sprite);

    }
}
