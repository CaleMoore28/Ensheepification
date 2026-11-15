using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    public bool bankrupt = false;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;           
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void MountScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void RequestQuit()
    {
        Application.Quit();
    }
}
