using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool paused;
    public bool Paused { get { return paused; } }


    private void Start()
    {
        paused = false;
        pausePanel.SetActive(false);
    }

    public void TogglePause()
    {
        if (paused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1.0f;
            paused = false;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
            paused = true;
        }
    }    

    public void OnResumePressed()
    {
        TogglePause();
    }

    public void OnOptionsPressed()
    {
        //TODO: Implement Options (eg. Volume)
        Debug.Log("TODO: Add Options Menu");
    }

    public void OnQuitToMenuPressed()
    {
        GameManager.Instance.MountScene("MainMenu");
    }

    public void OnQuitToDesktopPressed()
    {
        GameManager.Instance.RequestQuit();
    }
}
