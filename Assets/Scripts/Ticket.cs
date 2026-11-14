using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Ticket : MonoBehaviour
{

    [SerializeField] private GameObject ticketPanel;

    [SerializeField] private TextMeshProUGUI promptText;

    private string[] attributes = {"horns", "head", "body", "tail"};

    private string[] tags = {"cute", "evil", "basic", "fluffy"};

    public void setAttributes(string[] newAttributes)
    {
        attributes = newAttributes;
    }

    public void setTags(string[] newTags)
    {
        tags = newTags;
    }

    public void LoadText(object text, object attributeCount, object tagCount)
    {
        string final = text.ToString(); 
        List<string> currAttributes = new List<string>();
        List<string> currTags  = new List<string>();

        for (int i = 0; i < (int) attributeCount; i++) 
        {
            var regex = new Regex(Regex.Escape("$attribute"));
            currAttributes.Add(attributes[UnityEngine.Random.Range(0, attributes.Length)]);
            final = regex.Replace(final, currAttributes[i], 1);
    
        }
        for (int i = 0; i < (int) tagCount; i++) 
        {
            var regex = new Regex(Regex.Escape("$tag"));
            currTags.Add(tags[UnityEngine.Random.Range(0, tags.Length)]);
            final = regex.Replace(final, currTags[i], 1);

           
        }
        promptText.text=  final;

    }
}
