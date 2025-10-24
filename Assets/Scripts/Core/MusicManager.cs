using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

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

        // Start music
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void PlayMusic() => audioSource.Play();
    public void PauseMusic() => audioSource.Pause();
    public void StopMusic() => audioSource.Stop();
    public bool IsPlaying() => audioSource.isPlaying;
}