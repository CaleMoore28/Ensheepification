using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float mouseSensitivity = 1.0f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Hud hud;

    private bool isMovementEnabled = true;
    private Vector2 movement;
    private Vector2 mouseDelta;

    private const float INTERACT_DISTANCE = 1.0f;

    private Rigidbody playerRigidbody;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isMovementEnabled)
        {
            playerRigidbody.linearVelocity = Vector2.zero;
            return;
        }


        Vector3 sideways = transform.right * movement.x * moveSpeed * Time.fixedDeltaTime;
        Vector3 forwards = transform.forward * movement.y * moveSpeed * Time.fixedDeltaTime;

        playerRigidbody.linearVelocity = sideways + forwards;


        this.transform.eulerAngles = new Vector3(
            0.0f,
            this.transform.eulerAngles.y + mouseDelta.x * mouseSensitivity,
            0.0f
            );

        playerCamera.transform.localEulerAngles = new Vector3(
            playerCamera.transform.localEulerAngles.x + (-mouseDelta.y * mouseSensitivity),
            0.0f,
            0.0f
           );

        hud.ToggleInteractPrompt(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit,
            INTERACT_DISTANCE, interactableLayer));
    }

    public void ToggleMovement(bool toggle)
    {
        isMovementEnabled = toggle;
    }

    private void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>().normalized;
    }

    private void OnLook(InputValue inputValue)
    {
        mouseDelta = inputValue.Get<Vector2>();
    }

    private void OnInteract()
    {
        Debug.Log("Interacting!");

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit, 
            INTERACT_DISTANCE, interactableLayer))
        {
            Interactable interactable = raycastHit.collider.GetComponent<Interactable>();
            
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void OnPause()
    {
        FindAnyObjectByType<PauseMenu>().TogglePause();
    }

}
