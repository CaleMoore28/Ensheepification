using System;
using Unity.VisualScripting;
using UnityEngine;

public class TicketManager : MonoBehaviour
{
    [SerializeField] private TicketDisplay ticketDisplay;
    [Header("Tickets By Day")]
    [SerializeField] private TicketData[] dayOneTickets;
    [SerializeField] private TicketData[] dayTwoTickets;
    [SerializeField] private TicketData[] dayThreeTickets;
    [SerializeField] private TicketData[] dayFourTickets;
    [SerializeField] private TicketData[] dayFiveTickets;

    private int currentTicket = 0;
    private TicketData[] currentTicketQueue;

    private SatisfactionHandler satisfactionHandler;

    public Action OnAllTicketsFinished;


    private void Start()
    {
        satisfactionHandler = GetComponent<SatisfactionHandler>();
    }


    public void SetDay(int day)
    {
        currentTicketQueue = GetTicketQueue(day);
        currentTicket = 0;
        ticketDisplay.DisplayTicketData(currentTicketQueue[currentTicket]);
    }

    public void NextTicket()
    {
        currentTicket++;
        if (currentTicket >= currentTicketQueue.Length)
        {
            OnAllTicketsFinished?.Invoke();
        }
        else
        {
            ticketDisplay.DisplayTicketData(currentTicketQueue[currentTicket]);
        }
    }


    private TicketData[] GetTicketQueue(int day)
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
        else if (day == 4)
        {
            return dayFourTickets;
        }
        return dayFiveTickets;
    }

    public void EvaluateTicket(PartData[] parts)
    {
        satisfactionHandler.ScoreTicket(currentTicketQueue[currentTicket], parts);
        NextTicket();
    }
}
