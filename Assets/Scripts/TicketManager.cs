using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class TicketManager : MonoBehaviour
{
    [SerializeField] private TicketDisplay ticketDisplay;
    [Header("Tickets By Day")]
    [SerializeField] private object[,] dayOneTickets;
    [SerializeField] private object[,] dayTwoTickets;
    [SerializeField] object[,] dayThreeTickets;

    [SerializeField] private Ticket currentTicket;

    [SerializeField] private SatisfactionHandler satisfactionHandler;

    [SerializeField] private PromptGenerator promptGenerator;

    public Action OnAllTicketsFinished;


    private void Start()
    {
        satisfactionHandler = GetComponent<SatisfactionHandler>();
    }


    public void SetDay(int day)
    {
        promptGenerator.GenerateTicket();
        ticketDisplay.DisplayTicketData(currentTicket);
    }

    public void NextTicket()
    {  
        promptGenerator.GenerateTicket();
    }


    private object[,] GetTicketQueue(int day)
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
