using UnityEngine;

public class WindowManager : MonoBehaviour, Interactable
{
    [SerializeField] private TicketManager ticketManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public void Interact(PlayerController _playerController)
    {
        print("interact with Window");
        GameObject player = GameObject.FindWithTag("Player");
        GameObject sheep = player.transform.GetChild(1).gameObject;
        if (sheep){
            SheepManager sheepScript = sheep.GetComponent<SheepManager>();
            ticketManager.EvaluateTicket(sheepScript.bodyPartsList);
            sheepScript.ResetSheep();
        }
    }
}
