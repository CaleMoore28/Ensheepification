using UnityEngine;

[CreateAssetMenu(fileName = "TicketData", menuName = "Create New Ticket")]
public class TicketData : ScriptableObject
{
    [TextArea(5, 10)] public string prompt;
    public string[] tags;
    public Attribute[] requiredAttributes;
    public Attribute[] unwantedAttributes;
}
