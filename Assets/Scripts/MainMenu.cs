using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject titleButtonsParent;
    [SerializeField] private GameObject creditsParent;


    private void Start()
    {
        titleButtonsParent.SetActive(true);
        creditsParent.SetActive(false);
    }

    public void OnPlayPressed()
    {
        GameManager.Instance.MountScene("BeginningCutscene");
    }

    public void OnCreditsPressed()
    {
        if (titleButtonsParent.activeSelf)
        {
            titleButtonsParent.SetActive(false);
            creditsParent.SetActive(true);
        }
        else
        {
            titleButtonsParent.SetActive(true);
            creditsParent.SetActive(false);
        }
    }

    public void OnQuitPressed()
    {
        GameManager.Instance.RequestQuit();
    }

}
