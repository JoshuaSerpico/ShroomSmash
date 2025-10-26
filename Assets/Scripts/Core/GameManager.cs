using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static bool Paused;
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
        //swap this to use playerPrefs if we want this to persist across sessions
        // PlayerStats is used to track other player data, could be handled there as well
        //change back to true when you go back to working
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
