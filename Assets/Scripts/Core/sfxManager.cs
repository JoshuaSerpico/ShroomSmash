using UnityEngine;

public class sfxManager : MonoBehaviour
{
    public static sfxManager Instance { get; private set; }

    public static bool mute;

    [SerializeField] public AudioSource audioSource;

    [SerializeField] public AudioClip[] sfxClips;

    private void Awake()
    {
        // Singleton checkl
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (mute)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }

    public void PlayMusic() => audioSource.Play();
    public void PauseMusic() => audioSource.Pause();
    public void StopMusic() => audioSource.Stop();
    public bool IsPlaying() => audioSource.isPlaying;
}
