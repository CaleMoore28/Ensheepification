using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class BinStorage : MonoBehaviour
{
    [SerializeField] PartData partData;

    [SerializeField] bool meatIsSelected = false;

    private GameObject selectedMeat;

    [SerializeField] GameObject meatZone;

    [SerializeField] LayerMask meatZoneLayer;

    public void SelectMeat()
    {
        meatIsSelected = true;
        selectedMeat = Instantiate(partData.partPrefab, Vector3.zero, Quaternion.identity);
    }

    private void Update()
    {
        if (meatIsSelected && Mouse.current.leftButton.isPressed)
        {
            Vector3 mouse = Mouse.current.position.ReadValue();
            mouse = Camera.main.ScreenToWorldPoint(mouse);
            selectedMeat.transform.position = mouse;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            meatIsSelected = false;

            CheckIfInMeatZone();

            Destroy(selectedMeat);
            selectedMeat = null;
        }
    }

    private void CheckIfInMeatZone()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, 100f, meatZoneLayer);
    }

}
