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

    public void AddPart(PartData partData)
    {
        GameObject anchor = anchorData.getAnchorObject(partData.attribute);

        GameObject partPrefab = partData.partPrefab;

        if (anchor.GetComponentInChildren<Transform>() != null)
        {
            Destroy(anchor.GetComponentInChildren<PartManager>().gameObject);
            GameObject newPart = Instantiate(partPrefab, anchor.transform.position, Quaternion.identity, anchor.transform);
        }
    }

    private void Update()
    {
        /*if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            AddPart(testData.GetComponent<PartManager>().partDataScriptableObject);
        }
        */
    }
}
