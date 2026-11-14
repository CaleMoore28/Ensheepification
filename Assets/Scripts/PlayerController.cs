using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private void OnPause()
    {
        FindAnyObjectByType<PauseMenu>().TogglePause();
    }

}
