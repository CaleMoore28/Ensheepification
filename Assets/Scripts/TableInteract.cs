using Unity.Cinemachine;
using UnityEngine;

public class TableInteract : MonoBehaviour, Interactable
{
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineCamera tableCamera;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerAtTablePosition;

    [SerializeField] private BinManager binManager;

    PlayerController playerController;

    public void Interact(PlayerController _playerController)
    {
        playerController = _playerController;

        playerCamera.Priority = 0;
        tableCamera.Priority = 10;

        playerController.ToggleMovement(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        player.transform.position = playerAtTablePosition.transform.position;
    }

    public void EscapeTable()
    {
        playerCamera.Priority = 10;
        tableCamera.Priority = 0;


        playerController.ToggleMovement(true);

        binManager.NormalizeBinList();
    }
}
