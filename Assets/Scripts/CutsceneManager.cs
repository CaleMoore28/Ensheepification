using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private float cutsceneLength;
    [SerializeField] private string nextScene;

    private float timer;

    private void Start()
    {
        timer = cutsceneLength;
    }

    private void Update()
    {
        timer = Mathf.MoveTowards(timer, 0.0f, Time.deltaTime);

        if (timer == 0.0f)
        {
            GameManager.Instance.MountScene(nextScene);
        }
    }
}
