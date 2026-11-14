using UnityEngine;

public class TestInteractable : MonoBehaviour, Interactable
{
    public void Interact(PlayerController playerController)
    {
        Debug.Log("YOU INTERACTED WITH ME");
    }
}
