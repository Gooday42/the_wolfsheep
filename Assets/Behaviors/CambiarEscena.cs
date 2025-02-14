using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public LoadSceneMode ModoDeCarga;
    public string NombreDeLaEscena;
   public void Escena()
   {
     SceneManager.LoadScene(NombreDeLaEscena, ModoDeCarga);
   }

}
