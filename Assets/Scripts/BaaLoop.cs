using UnityEngine;

public class BaaLoop : MonoBehaviour
{
    [SerializeField] private AudioClip baaClip;
    [SerializeField] private float baaMin = 5.0f;
    [SerializeField] private float baaMax = 15.0f;

    private float baaTimer;

    private AudioSource baaSource;


    void Start()
    {
        baaSource = GetComponent<AudioSource>();

        baaTimer = Random.Range(baaMin, baaMax);
    }

    // Update is called once per frame
    void Update()
    {
        baaTimer = Mathf.MoveTowards(baaTimer, 0.0f, Time.deltaTime);

        if (baaTimer == 0.0f)
        {
            AudioManager.Instance.PlayEffect(baaSource, baaClip);
            Debug.Log("BAA BAA");
            baaTimer = Random.Range(baaMin, baaMax);
        }
    }
}
