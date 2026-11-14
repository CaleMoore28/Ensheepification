using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void OnPlayPressed()
    {
        GameManager.Instance.MountScene("Level");
    }

    public void OnCreditsPressed()
    {

    }

    public void OnQuitPressed()
    {
        GameManager.Instance.RequestQuit();
    }

}
