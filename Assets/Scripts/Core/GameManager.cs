using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static bool Paused;
    public static bool GameOver;
    public static event Action<bool> OnPauseChanged; // passes the new pause state

    public static bool firstTime;
    public static bool howToPlay;
    private void Awake()
    {
        // Singleton check
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Paused = false;
        howToPlay = false;

        firstTime = false;
    }

    public void SetPause(bool paused)
    {
        if (Paused == paused) return;

        Paused = paused;
        OnPauseChanged?.Invoke(Paused); // notify all subscribers
    }

    // Optional: toggle function
    public void TogglePause() => SetPause(!Paused);
}
