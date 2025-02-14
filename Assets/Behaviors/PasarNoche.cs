using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarNoche : MonoBehaviour
{


    public bool twiling = false;
  
    
    public void Twiling()
    {
        if(!twiling)
        {
            StartCoroutine(PassNigth());
        }

        twiling = true;
    }
    IEnumerator PassNigth()
    {
    DaysManager.Nights++;
    DaysManager.Days++;


    yield return new WaitForSeconds(3.0f);

    GetComponent<CambiarEscena>().Escena();
    //FindAnyObjectByType<VirginaWolf>().Hunt();

    //DaysManager.NewDay?.Invoke();

    }
}
