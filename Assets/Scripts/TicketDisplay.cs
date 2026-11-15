using TMPro;
using UnityEngine;

public class TicketDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ticketText;
    [SerializeField] private Ticket testTicket;


    private void Start()
    {
        DisplayTicketData(testTicket);
    }

    public void DisplayTicketData(Ticket ticketData)
    {
        if (ticketData){    
            ticketText.text = ticketData.prompt;
        }
        print($"ticket prompt currently:{ticketText.text}");
    }
}
