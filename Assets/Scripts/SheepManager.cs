using UnityEngine;
using UnityEngine.InputSystem;

public class SheepManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private AnchorData anchorData;

    public GameObject testData;

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
