using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class TicketManager : MonoBehaviour
{
    [SerializeField] private TicketDisplay ticketDisplay;
    [Header("Tickets By Day")]

    // format is prompt, number of attributes, number of tags
    // tags: cute, evil, fluffy, basic, [corrupted]
    // attributes: horns, wings, tails
    [SerializeField] private object[,] dayOneTickets =
    {
        {"Doll-E, give me a sheep with a $tag $attribute.", 1, 1},      
        {"PROMPT: Generate a sheep with $attribute attribute and $tag tag", 1, 1},
        {"Generate me a sheep that is $tag enough for me to hang with after a long day.!", 0, 1},
    };
    [SerializeField] private object[,] dayTwoTickets=
    {
        {"Doll-E!!! I want a $tag sheep with a $tag $attribute.", 1, 2},
        {"Generate me a sheep that feels like a $tag hug!", 0, 1},
        {"Generate me a sheep that reminds me of my incredibly $tag coworker Carl. Give it a $attribute.", 1, 1}
        //{"Prompt: Generate a sheep with $attribute attribute and $tag tag", 1, 1},
    };
    [SerializeField] object[,] dayThreeTickets=
    {
        {"@Grok generate me a sheep that I can give my $tag boyfriend. Make a sheep that says “wrap me up in your big, $tag arms.” But make sure it’s not too nice or I can’t dump him next year." 
            , 0, 2},
        {"Doll-E!!! I need a sheep with rogue-like elements, make it $tag, and spit on it.", 0, 1},
        {"I want a sheep with a $tag $attribute enough to keep the monsters guessing!", 1, 1},
        //{"Prompt: Generate a sheep with $attribute attribute and $tag tag", 1, 1},
        {"Generate me a sheep that is so $tag that it will intimidate a bear with one, $tag stare.", 0, 1}
    };

    [SerializeField] string[] tags = {"cute", "evil", "basic", "fluffy", "chill", "fantastical", "old-fashioned", "baazarrre", "hdkjdkfjejufiop", "Quirked Up White Boy"};

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
        if (day = 3)
        {
            currentTicket.setTags(tags);
        }
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
