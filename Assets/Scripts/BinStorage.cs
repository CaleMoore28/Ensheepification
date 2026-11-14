using System.Collections;
using Unity.Cinemachine;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class BinStorage : MonoBehaviour
{
    [SerializeField] PartData partData;

    [SerializeField] bool meatIsSelected = false;

    private GameObject selectedMeat;

    [SerializeField] private GameObject meatZone;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask meatMask;

    [SerializeField] private float meatCarryHeight = 0.2f;

    [SerializeField] Camera cinemachineCamera;

    [Header("Dependencies")]
    [SerializeField] SheepManager sheepManager;

    private bool buttonWasJustPressed = false;

    public void SelectMeat()
    {
        Debug.Log("Meat Selected");
        meatIsSelected = true;
        selectedMeat = Instantiate(partData.partPrefab, Vector3.zero, Quaternion.identity);

        buttonWasJustPressed = true;
        StartCoroutine(ButtonCooldown());
    }

    IEnumerator ButtonCooldown()
    {
        yield return new WaitForSeconds(0.1f);

        buttonWasJustPressed = false;
    }

    private void Update()
    {
        if (meatIsSelected)
        {
            Vector3 mouse = Mouse.current.position.ReadValue();

            Ray ray = cinemachineCamera.ScreenPointToRay(mouse);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.tag == "TableZone")
                {
                    Vector3 temp = hit.point + new Vector3(0, meatCarryHeight, 0);
                    selectedMeat.transform.position = temp;
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (meatIsSelected && Mouse.current.leftButton.wasPressedThisFrame && !buttonWasJustPressed)
        {
            meatIsSelected = false;

            CheckIfInMeatZone();

            Destroy(selectedMeat);
            selectedMeat = null;
        }
    }

    private void CheckIfInMeatZone()
    {
        Vector3 mouse = Mouse.current.position.ReadValue();

        Ray ray = cinemachineCamera.ScreenPointToRay(mouse);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.collider.gameObject);
            

            if (hit.collider.gameObject.name == "MeatZone")
            {
                sheepManager.AddPart(selectedMeat.GetComponent<PartManager>().partDataScriptableObject);
            }
            else
            {
                Debug.Log("Meat failure");
            }
        }
    }
}
