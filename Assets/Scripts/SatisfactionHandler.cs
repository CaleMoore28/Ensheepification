using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SatisfactionHandler : MonoBehaviour
{
    private float customerSatisfactionScore;
    private int completedTickets;
    

    public void ResetSatisfactionScore()
    {
        customerSatisfactionScore = 0.0f;
        completedTickets = 0;
    }

    public void ScoreTicket(TicketData ticket, PartData[] parts)
    {
        HashSet<string> correctTags = new HashSet<string>();
        HashSet<string> extraTags = new HashSet<string>();

        HashSet<Attribute> attributes = new HashSet<Attribute>();


        foreach (PartData part in parts)
        {
            foreach (string tag in part.tags)
            {
                if (ticket.tags.Contains(tag))
                {
                    correctTags.Add(tag);
                }
                else
                {
                    extraTags.Add(tag);
                }
            }

            if (ticket.requiredAttributes.Contains(part.attribute))
            {
                attributes.Add(part.attribute);
            }
        }

        Assert.LessOrEqual(correctTags.Count, ticket.tags.Length);
        Assert.LessOrEqual(attributes.Count, ticket.requiredAttributes.Length);

        float tagScore = Mathf.Max(correctTags.Count - extraTags.Count, 0.0f) / (float)ticket.tags.Length;
        float attributeScore = attributes.Count / (float)ticket.requiredAttributes.Length;

        customerSatisfactionScore += tagScore * attributeScore;

        completedTickets++;
    }

    public float GetCustomerSatisfaction()
    {
        return customerSatisfactionScore / (float)completedTickets;
    }
}
