using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DisplayNeighbourSuspicionInfo : MonoBehaviour
{
    public TMP_Text text;

    public void ChangeText()
    {
        Citizen thisGuy = GetComponent<ShowCitizenInfo>().thisGuy;
        var SuspectLevel = FindAnyObjectByType<TalkWithCitizen>().citizenToTalk.Neighbours[thisGuy];

        string finalMessage = "";

        if (SuspectLevel <= 10)
        {
            finalMessage = $"I don't think {thisGuy.name} is the wolf.";
        }
        else if (SuspectLevel <= 20)
        {
            finalMessage = $"I have a slight suspicion that {thisGuy.name} might be the wolf.";
        }
        else if (SuspectLevel <= 30)
        {
            finalMessage = $"{thisGuy.name} is a little suspicious.";
        }
        else if (SuspectLevel <= 40)
        {
            finalMessage = $"Something about {thisGuy.name} feels off.";
        }
        else if (SuspectLevel <= 50)
        {
            finalMessage = $"I'm starting to think {thisGuy.name} could be the wolf.";
        }
        else if (SuspectLevel <= 60)
        {
            finalMessage = $"I have a moderate suspicion that {thisGuy.name} is the wolf.";
        }
        else if (SuspectLevel <= 70)
        {
            finalMessage = $"I strongly suspect {thisGuy.name} is the wolf.";
        }
        else if (SuspectLevel <= 80)
        {
            finalMessage = $"I'm almost convinced {thisGuy.name} is the wolf!";
        }
        else if (SuspectLevel <= 90)
        {
            finalMessage = $"I have no doubt—{thisGuy.name} is the wolf!";
        }
        else // SuspectLevel > 90
        {
            finalMessage = $"There's no question. {thisGuy.name} is absolutely the wolf!";
        }

        text.text = finalMessage;
    }
}
