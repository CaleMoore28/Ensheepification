using TMPro;
using UnityEngine;

public class TicketDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ticketText;
    [SerializeField] private TicketData testTicket;


    private void Start()
    {
        DisplayTicketData(testTicket);
    }

    public void DisplayTicketData(TicketData ticketData)
    {
        ticketText.text = ticketData.prompt;
    }
}
