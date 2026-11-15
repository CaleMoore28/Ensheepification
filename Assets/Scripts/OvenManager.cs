using UnityEngine;

public class OvenManager : MonoBehaviour, Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float timer;
    private bool active = false;
    private GameObject sheep;
    
    private bool SheepInOven = false;

    
    public void Interact(PlayerController _playerController)
    {
        print("interact with Oven");
        GameObject player = GameObject.FindWithTag("Player");
        sheep = player.transform.GetChild(1).gameObject;
        if (sheep && !SheepInOven){
            timer = 3.0f;
            active = true;
            sheep.SetActive(false);
            SheepInOven = true;
            this.GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(1f, 0f, 0f));
            print("cook the sheep");
        }
        if (SheepInOven && !active && sheep){
            sheep.SetActive(true);
            SheepInOven = false;
            sheep = null;
            this.GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(.5f, .5f, .5f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timer = Mathf.MoveTowards(timer, 0.0f, Time.deltaTime);
            if (timer <= 0)
            {
                active = false;
                 this.GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(0f, 1f, 0f));

            }
        }
    }
}
