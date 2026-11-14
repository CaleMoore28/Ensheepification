using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    [SerializeField] private AudioSource effectSource;

    private float effectVolume;


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

    public void PlayEffect(AudioClip effectClip)
    {
        effectSource.PlayOneShot(effectClip, effectVolume);
    }

    public void SetEffectVolume(float volume)
    {
        effectVolume = Mathf.Clamp(volume, 0.0f, 1.0f);
    }
}
