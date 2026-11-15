using UnityEngine;
using System;

public class AnchorData : MonoBehaviour
{
    [SerializeField] private GameObject headAnchor;

    [SerializeField] private GameObject bodyAnchor;
    
    [SerializeField] private GameObject hornsAnchor;

    [SerializeField] private GameObject legsAnchor;

    private Attribute attribute = Attribute.HEAD;

    public GameObject getAnchorObject(Attribute inputAttribute)
    {
        attribute = inputAttribute;

        switch (attribute)
        {
            default:
                return null;

            // Head
            case (Attribute.HEAD):
                return headAnchor;

            // Body
            case (Attribute.BODY):
                return bodyAnchor;

            // Horns
            case (Attribute.HORNS):
                return hornsAnchor;

            // Legs
            case (Attribute.LEGS):
                return legsAnchor;

            // Legs
            case (Attribute.TAIL):
                return tailAnchor;

            // Wings
            case (Attribute.WINGS):
                return wingsAnchor;

        }
    }
}