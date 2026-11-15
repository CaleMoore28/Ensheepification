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

    public void ScoreTicket(Ticket ticket, List<GameObject> parts)
    {
        HashSet<string> correctTags = new HashSet<string>();
        HashSet<string> extraTags = new HashSet<string>();

        HashSet<Attribute> attributes = new HashSet<Attribute>();

        bool forbiddenAttributes = false;

        foreach (GameObject parentObj in parts)
        {
            if (parentObj == null)
            {
                continue;
            }

            PartData part = parentObj.GetComponent<PartManager>().partDataScriptableObject;

            if (part == null)
            {
                continue;
            }

            foreach (string tag in part.tags)
            {
                if (ticket.requiredTags.Contains(tag))
                {
                    correctTags.Add(tag);
                }
                else
                {
                    extraTags.Add(tag);
                }
            }

            if (ticket.requiredAttributes.Contains(part.attribute.ToString()))
            {
                attributes.Add(part.attribute);
            }
            else if (ticket.unwantedAttributes.Contains(part.attribute.ToString()))
            {
                forbiddenAttributes = true;
            }
        }


        float tagScore = Mathf.Max(correctTags.Count - extraTags.Count, 0.0f) / (float)ticket.requiredTags.Count;
        float attributeScore = attributes.Count / (float)ticket.requiredAttributes.Count;
        float forbiddenScore = 1.0f;
        
        if (forbiddenAttributes)
        {
            forbiddenScore = 0.5f;
        }

        customerSatisfactionScore += tagScore * attributeScore * forbiddenScore;

        completedTickets++;
    }

    public float GetCustomerSatisfaction()
    {
        return customerSatisfactionScore / (float)completedTickets;
    }
}
