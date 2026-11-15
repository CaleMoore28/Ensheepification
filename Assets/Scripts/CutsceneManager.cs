using Unity.VisualScripting;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private float cutsceneLength;
    [SerializeField] private string nextScene;
    [SerializeField] private Camera cutsceneCamera;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

    private float timer;

    public bool endScene = false;

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

        cutsceneCamera.transform.position = Vector3.Lerp(startPos.position, endPos.position, 1 - (timer / cutsceneLength));
    }
}
