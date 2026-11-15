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
        {"Prompt 1: $tag", 0, 1},
        {"Prompt 2: $attribute", 1, 0},
        {"Prompt 1: $attribute $tag", 1, 1},
    };
    [SerializeField] private object[,] dayTwoTickets;
    [SerializeField] object[,] dayThreeTickets;

    [SerializeField] private Ticket currentTicket;

    [SerializeField] private SatisfactionHandler satisfactionHandler;

    [SerializeField] private PromptGenerator promptGenerator;

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
