using UnityEngine;

public class TestInteractable : MonoBehaviour, Interactable
{
    public void Interact()
    {
        Debug.Log("YOU INTERACTED WITH ME");
    }
}
