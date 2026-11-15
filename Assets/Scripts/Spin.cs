using Unity.VisualScripting;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;

    [Header("Dependencies")]
    [SerializeField] private SheepManager sheepManager;

    private void Update()
    {
        if (!sheepManager.cookable)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
