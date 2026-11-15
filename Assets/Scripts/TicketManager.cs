using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class TicketManager : MonoBehaviour
{
    [SerializeField] private TicketDisplay ticketDisplay;
    [Header("Tickets By Day")]

    // format is prompt, attribute number, tag number
    [SerializeField] private object[,] dayOneTickets =
    {
        {"Generate me a sheep that feels like a $tag hug!", 0, 1},
        {"Doll-E, I want a %tag sheep, with $attribute.", 1, 1},
        {"Prompt 1: $attribute $tag", 1, 1},
    };
    [SerializeField] private object[,] dayTwoTickets=
    {
        {"Generate me a sheep that feels like a $tag hug!", 0, 1},
        {"Doll-E, I want a %tag sheep, with $attribute.", 1, 1},
        {"Prompt 1: $attribute $tag", 1, 1},
    };
    [SerializeField] private object[,] dayThreeTickets=
    {
        // {"Generate me a sheep that I can give my $tag boyfriend. Make me a sheep that says “wrap me up in your big, $tag arms.” But make sure it’s not too nice or I can’t dump him next year." 
        //     , 0, 2},
        // {"SheepGPT, generate me a sheep with rogue-like elements, make it $tag, and spit on it.", 0, 1},
        // {"Prompt 1: $attribute $tag", 1, 1},
    };

    [SerializeField] private Ticket currentTicket;

    [SerializeField] private SatisfactionHandler satisfactionHandler;

    [SerializeField] private PromptGenerator promptGenerator;

// Generate me a sheep that is BLANK enough to keep the monsters guessing!

// Generate me a sheep that feels like a big BLANK blanket.

// Generate me a sheep that is BLANK enough for me to hang with after a long day.

// Generate me a sheep that is so BLANK that it will intimidate a bear with one, BLANK stare. 

// Generate me a sheep that reminds me of my incredibly BLANK coworker Carl.

// Generate me a sheep that is BLANK as my grandma but not as much so as my grandpa. Make sure it is as BLANK as my grandpa but not as much as my grandma.
    

    public Action OnAllTicketsFinished;

    public void SetDay(int day)
    {
        promptGenerator.promptOptions = SetTicketQueue(day);
        promptGenerator.GenerateTicket();
        ticketDisplay.DisplayTicketData(currentTicket);
    }

    public void NextTicket()
    {  
        promptGenerator.GenerateTicket();
        ticketDisplay.DisplayTicketData(currentTicket);
    }


    private object[,] SetTicketQueue(int day)
    {
        if (day == 1)
        {
            return dayOneTickets;
        }
        else if (day == 2)
        {
            return dayTwoTickets;
        }
        else if (day == 3)
        {
            return dayThreeTickets;
        }
        return null;
    }

    public void EvaluateTicket(List<GameObject> parts)
    {
        satisfactionHandler.ScoreTicket(currentTicket, parts);
        NextTicket();
    }
}
