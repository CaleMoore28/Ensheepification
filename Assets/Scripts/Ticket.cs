using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Ticket : MonoBehaviour
{

    private string[] attributes = {"horns", "head", "body", "tail"};

    private string[] tags = {"cute", "evil", "basic", "fluffy"};

    public List<string> requiredAttributes = new List<string>();
    public List<string> requiredTags  = new List<string>();

    public List<string> unwantedAttributes = new List<string>();

    public string prompt;

    
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
        prompt = null;
        prompt = text.ToString(); 
        requiredAttributes = new List<string>();
        requiredTags = new List<string>();

        for (int i = 0; i < (int) attributeCount; i++) 
        {
            var regex = new Regex(Regex.Escape("$attribute"));
            requiredAttributes.Add(attributes[UnityEngine.Random.Range(0, attributes.Length)]);
            prompt = regex.Replace(prompt, requiredAttributes[i], 1);
    
        }
        for (int i = 0; i < (int) tagCount; i++) 
        {
            var regex = new Regex(Regex.Escape("$tag"));
            requiredTags.Add(tags[UnityEngine.Random.Range(0, tags.Length)]);
            prompt = regex.Replace(prompt, requiredTags[i], 1);

           
        }

    }
}
