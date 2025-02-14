using System.Collections;
using TMPro;
using UnityEngine;

public class AnotherVictimOfTime : MonoBehaviour
{
    public static AnotherVictimOfTime instance;

    [Header("Time Settings")]
    public float realTimeMinutes = 1; // How many real minutes equal 1 in-game day
    public float gameDaysEquivalent = 1; // How many in-game days per realTimeMinutes

    public float TimeFactor { get; private set; } // Internal time speed multiplier

    private float seconds = 0;
    private int minutes = 0;
    private int hours = 6;

    private TMP_Text clockText;
    private int lastUpdatedMinute = -1; // Store last updated minute to avoid redundant updates

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        clockText = GetComponent<TMP_Text>();
        CalculateTimeFactor();
        StartCoroutine(CoolTick());
    }

    void Update()
    {
        seconds += Time.deltaTime * TimeFactor;

        if (seconds >= 60)
        {
            seconds = 0;
            minutes++;

            if (minutes >= 60)
            {
                minutes = 0;
                hours++;

                if (hours >= 18)
                {
                    hours = 6;
                }
            }

            // Round minutes to nearest multiple of 10
            int roundedMinutes = (minutes / 10) * 10;

            // Update clock only when a new 10-minute mark is reached
            if (roundedMinutes != lastUpdatedMinute)
            {
                lastUpdatedMinute = roundedMinutes;
                UpdateClock();
            }
        }
    }

    void UpdateClock()
    {
        clockText.text = $"{hours:00}:{lastUpdatedMinute:00}h";
    }

    IEnumerator CoolTick()
    {
        while (true)
        {
            clockText.text = $"{hours:00}:{lastUpdatedMinute:00}h";
            yield return new WaitForSeconds(1);
            clockText.text = $"{hours:00} {lastUpdatedMinute:00}h";
            yield return new WaitForSeconds(1);
        }
    }

    void CalculateTimeFactor()
    {
        if (realTimeMinutes > 0 && gameDaysEquivalent > 0)
        {
            TimeFactor = (24 * 60) / (realTimeMinutes * 60) * gameDaysEquivalent;
        }
    }

    void OnValidate()
    {
        CalculateTimeFactor();
    }
}
