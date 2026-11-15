using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SheepManager : MonoBehaviour, Interactable
{
    [Header("Dependencies")]
    [SerializeField] private AnchorData anchorData;
    [SerializeField] private TableInteract tableInteract;

    public GameObject testData;

    private bool complete;

    public List<GameObject> bodyPartsList;

    public bool cookable = false;

    [SerializeField] private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider.enabled = false;

        int i = 0;
        foreach (GameObject bodyPartObject in bodyPartsList)
        {
            bodyPartObject.GetComponent<MeshFilter>().mesh = null;
            bodyPartObject.GetComponent<PartManager>().partDataScriptableObject = null;
            i += 1;
        }
    }

    public void Interact(PlayerController _playerController)
    {
        print("interact with sheep");
        //TODO Remove Line
        if (cookable)
        {
            print("sheep child?");
            GameObject player = GameObject.FindWithTag("Player");
            transform.parent = player.transform;
        }
        this.gameObject.layer = default;
    }

    public void AddPart(PartData partData)
    {
        GameObject anchor = anchorData.getAnchorObject(partData.attribute);

        anchor.GetComponentInChildren<PartManager>().partDataScriptableObject = partData;
        anchor.GetComponentInChildren<MeshFilter>().mesh = partData.mesh;

  /*      //GameObject partPrefab = partData.partPrefab;

        GameObject oldPart = null;
        PartData oldPartData = null;
        try
        {
            oldPart = anchor.GetComponentInChildren<PartManager>().gameObject;
            oldPartData = oldPart.GetComponentInChildren<PartManager>().partDataScriptableObject;
        }
        catch { }

        if (oldPart == null)
        {
            oldPart.GetComponent<MeshFilter>().mesh = partData.mesh;
            oldPartData = partData;
            //GameObject newPart = Instantiate(partPrefab, anchor.transform.position, Quaternion.Euler(-90f, 0f, 0f), anchor.transform);
            //bodyPartsList.Add(partData);
        }

        if (oldPart != null)
        {
            //bodyPartsList.Remove(oldPart);
            //Destroy(oldPart);

            oldPart.GetComponent<MeshFilter>().mesh = partData.mesh;
            oldPartData = partData;

            //GameObject newPart = Instantiate(partPrefab, anchor.transform.position, Quaternion.Euler(-90f, 0f, 0f), anchor.transform);
            //bodyPartsList.Add(newPart);
        }

        */
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
        tableInteract.EscapeTable();

        boxCollider.enabled = true;
    }

    public void ResetSheep()
    {
        cookable = false;

        int i = 0;
        foreach (GameObject bodyPartObject in bodyPartsList)
        {
            bodyPartObject.GetComponent<MeshFilter>().mesh = null;
            bodyPartObject.GetComponent<PartManager>().partDataScriptableObject = null;
            i += 1;
        }

        boxCollider.enabled = false;
    }
}
