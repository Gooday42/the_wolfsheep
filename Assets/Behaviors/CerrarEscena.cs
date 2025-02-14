using UnityEngine;
using UnityEngine.SceneManagement;

public class CerrarEscena : MonoBehaviour
{
    public string sceneName = "Noche"; // Scene name to unload, adjustable in the Inspector

    public void CloseScene()
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
            Debug.Log($"Scene '{sceneName}' has been unloaded.");
        }
        else
        {
            Debug.LogWarning($"Scene '{sceneName}' is not loaded or does not exist.");
        }
    }
}
