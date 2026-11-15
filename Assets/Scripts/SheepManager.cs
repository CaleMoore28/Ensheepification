using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SheepManager : MonoBehaviour, Interactable
{
    [Header("Dependencies")]
    [SerializeField] private AnchorData anchorData;
    [SerializeField] private TableInteract tableInteract;
    [SerializeField] private Spin spin;

    public GameObject testData;

    private bool complete;

    [SerializeField] public List<GameObject> bodyPartsList;

    public bool cookable = false;
    public bool spinningEnabled;

    [SerializeField] private float heldSize = 0.33f;

    [SerializeField] private BoxCollider boxCollider;

    [SerializeField] private GameObject sheepResetOffset;

    [SerializeField] private MoneyManager moneyManager;

    private void Start()
    {
        boxCollider.enabled = false;

        int i = 0;
        foreach (GameObject bodyPartObject in bodyPartsList)
        {
            bodyPartObject.GetComponent<MeshFilter>().mesh = null;

            try
            {
                bodyPartObject.GetComponent<PartManager>().partDataScriptableObject = null;
            }
            catch { }

            i += 1;

            spinningEnabled = true;
            spin.hasChangedSpinState = false;
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
            Debug.Log("Player object is " + player);
            GameObject cameraPos = player.GetComponentInChildren<Testing>().gameObject;
            Debug.Log("cameraPos " + cameraPos);
            transform.parent = cameraPos.transform;
            //transform.parent = player.transform;
        }
        this.gameObject.layer = default;
    }

    public void AddPart(PartData partData)
    {

        int totalCost = 0;

        GameObject anchor = anchorData.getAnchorObject(partData.attribute);

        totalCost -= partData.cost;

        if (anchor.GetComponentInChildren<PartManager>().partDataScriptableObject)
        {
                totalCost += anchor.GetComponentInChildren<PartManager>().partDataScriptableObject.cost;
        }
            moneyManager.IncrementMoney(totalCost); 

        anchor.GetComponentInChildren<PartManager>().partDataScriptableObject = partData;
        anchor.GetComponentInChildren<MeshFilter>().mesh = partData.mesh;

        spinningEnabled = true;
        spin.hasChangedSpinState = false;
    }

   public void TryReadyToCook()
    {
        int necessaryPartCounter = 0;

        foreach (GameObject bodyPart in bodyPartsList)
        {
            PartData bodyPartData = bodyPart.GetComponent<PartManager>().partDataScriptableObject;

            Debug.Log("BodyPartData is " + bodyPartData);

            if (bodyPartData == null)
            {
                continue;
            }

            //Head
            if (bodyPartData.attribute == Attribute.HEAD)
            {
                necessaryPartCounter += 1;
            }
            //Body
            else if (bodyPartData.attribute == Attribute.BODY)
            {
                necessaryPartCounter += 1;
            }
            // Legs
            else if (bodyPartData.attribute == Attribute.LEGS)
            {
                necessaryPartCounter += 1;
            }
        }

        if (necessaryPartCounter >= 3)
        {
            ReadyToCook();
        }

    }

    private void ReadyToCook()
    {
        cookable = true;
        
        tableInteract.EscapeTable();

        boxCollider.enabled = true;

        spinningEnabled = false;

        gameObject.transform.localScale = new Vector3(heldSize, heldSize, heldSize);
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

        spinningEnabled = true;
        spin.hasChangedSpinState = false;

        gameObject.transform.localScale = Vector3.one;


        this.gameObject.layer = 6;

        transform.parent = null;
        transform.position = sheepResetOffset.transform.position;
    }
}
