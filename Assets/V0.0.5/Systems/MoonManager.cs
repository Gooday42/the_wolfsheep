using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MoonManager : MonoBehaviour
{
    [System.Serializable]
    public class GameEvent
    {
        public string name;
        public float probability; // e.g., 0.3 means 30% chance
        public System.Action onExecute; // Function to execute
    }

    public List<GameEvent> events;
    
    void Start()
    {
        if (IsFullMoon())
        {
            Debug.Log("It's a full moon night!");
            TriggerRandomEvent();
        }
    }

    bool IsFullMoon()
    {
        // Example logic: Assume full moon every 7 in-game days
        int gameDay = GetGameDay(); // Replace with your in-game time system
        return gameDay % 7 == 0;
    }

    void TriggerRandomEvent()
    {
        GameEvent selectedEvent = GetRandomEvent();
        if (selectedEvent != null)
        {
            Debug.Log($"Triggered Event: {selectedEvent.name}");
            selectedEvent.onExecute?.Invoke();
        }
    }

    GameEvent GetRandomEvent()
    {
        float totalWeight = 0;
        foreach (var ev in events)
            totalWeight += ev.probability;

        float randomPoint = Random.Range(0, totalWeight);
        float cumulative = 0;

        foreach (var ev in events)
        {
            cumulative += ev.probability;
            if (randomPoint <= cumulative)
                return ev;
        }

        return null;
    }

    int GetGameDay()
    {
        // Replace with actual game time system
        return (int)Time.time / 10; // Simulated day count
    }

    private void Update() {
        
    }
}
