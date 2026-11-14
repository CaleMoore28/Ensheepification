using UnityEngine;

public class PromptGenerator : MonoBehaviour
{
    public PromptOptions promptOptions;
    public Ticket ticket;
    
    public void GenerateTicket()
    {
        int ticketSelect = UnityEngine.Random.Range(0, promptOptions.dialogue.Length/3);
        ticket.LoadText(promptOptions.dialogue[ticketSelect, 0], promptOptions.dialogue[ticketSelect, 1], promptOptions.dialogue[ticketSelect, 2]);
    }
}
