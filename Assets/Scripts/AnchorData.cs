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
            case ((Attribute)0):
                return headAnchor;

            // Body
            case ((Attribute)1):
                return bodyAnchor;

            // Horns
            case ((Attribute)2):
                return hornsAnchor;

            // Legs
            case ((Attribute)3):
                return legsAnchor;

        }
    }
}