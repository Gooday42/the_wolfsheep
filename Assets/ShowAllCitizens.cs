  using UnityEngine;

public class ShowAllCitizens : MonoBehaviour
{
   [SerializeField] public GameObject ContainerPrefab;


    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        foreach(Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Citizen thisGuy in FindObjectsByType<Citizen>(FindObjectsSortMode.None))
        {
            Debug.Log(thisGuy.name);
            GameObject currentContainter = Instantiate(ContainerPrefab,transform);
            currentContainter.GetComponent<ShowCitizenInfo>().thisGuy =thisGuy;
            currentContainter.SetActive(true);

        }
    }
}
