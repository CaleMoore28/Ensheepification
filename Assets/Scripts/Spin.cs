using Unity.VisualScripting;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;

    [Header("Dependencies")]
    [SerializeField] private SheepManager sheepManager;

    public bool hasChangedSpinState;

    private void Start()
    {
        hasChangedSpinState = false;
    }

    private void Update()
    {
        if (sheepManager.spinningEnabled)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else if (sheepManager.spinningEnabled && !hasChangedSpinState)
        {
            transform.eulerAngles = Vector3.zero;
            hasChangedSpinState = true;
        }
    }
}
