using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SheepManager : MonoBehaviour, Interactable
{
    [Header("Dependencies")]
    [SerializeField] private AnchorData anchorData;

    public GameObject testData;

    private bool complete;

    public void Interact(PlayerController _playerController)
    {
        print("interact with sheep");
        complete = true;
        //TODO Remove Line
        if (complete){
            print("sheep child?");
            GameObject player = GameObject.FindWithTag("Player");
            transform.parent = player.transform;
        }
        this.gameObject.layer = default;
    }

    [SerializeField] private List<GameObject> bodyPartsList;

    private bool cookable = false;


    public void AddPart(PartData partData)
    {
        GameObject anchor = anchorData.getAnchorObject(partData.attribute);

        GameObject partPrefab = partData.partPrefab;

        GameObject oldPart = anchor.GetComponentInChildren<Transform>().gameObject;
        
        if (oldPart != null)
        {
            bodyPartsList.Remove(oldPart);
            Destroy(oldPart);
            GameObject newPart = Instantiate(partPrefab, anchor.transform.position, Quaternion.identity, anchor.transform);
            bodyPartsList.Add(newPart);
        }
        else
        {
            GameObject newPart = Instantiate(partPrefab, anchor.transform.position, Quaternion.identity, anchor.transform);
            bodyPartsList.Add(newPart);
        }
    }

    public void TryReadyToCook()
    {
        int necessaryPartCounter = 0;

        foreach (GameObject bodyPart in bodyPartsList)
        {
            PartData bodyPartData = bodyPart.GetComponent<PartManager>().partDataScriptableObject;
            //Head
            if (bodyPartData.attribute == (Attribute) 0)
            {
                necessaryPartCounter += 1;
            }
            //Body
            else if (bodyPartData.attribute == (Attribute) 1)
            {
                necessaryPartCounter += 1;
            }
            // Legs
            else if (bodyPartData.attribute == (Attribute) 3)
            {
                necessaryPartCounter += 1;
            }
        }

        if (necessaryPartCounter == 3)
        {
            ReadyToCook();
        }

    }

    private void ReadyToCook()
    {
        cookable = true;
    }

    public void ResetSheep()
    {
        cookable = false;
    }
}
