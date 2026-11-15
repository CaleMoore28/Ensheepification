using UnityEngine;

public class PromptGenerator : MonoBehaviour
{
    public object[,] promptOptions;
    public Ticket ticket;
    
    public void GenerateTicket()
    {
        int ticketSelect = UnityEngine.Random.Range(0, promptOptions.Length/3);
        ticket.LoadText(promptOptions[ticketSelect, 0], promptOptions[ticketSelect, 1], promptOptions[ticketSelect, 2]);
    }
}
