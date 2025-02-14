using System.Collections;
using UnityEngine;

public class UI_OpenGameObjectOnClick : MonoBehaviour
{
    public GameObject OpenThis;
    public int waitThisSeconds;
    public void Open_Close()
    {
        StartCoroutine(open());
    }

    IEnumerator open()
    {
        yield return new WaitForSeconds(waitThisSeconds);
        OpenThis.SetActive(true);        

    }
}
