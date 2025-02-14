using Unity.VisualScripting;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    public static bool stoped = false;
    public static void Stop()
    {
        if (!StopGame.stoped)
        {
            Time.timeScale = 0.00f;
            StopGame.stoped = true;
        }
    }

    public static void Continue()
    {
        if (StopGame.stoped)
        {
            Time.timeScale = 1.0f;
            StopGame.stoped = false;
        }
    }
    
}
