using System.Collections;
using TMPro;
using UnityEngine;

public class TimerUpdate : MonoBehaviour
{
    public TMP_Text timerText;
    private bool Paused = false;
    private int lastDisplayedSeconds = -1; // avoid updating UI every frame

    [Header("Countdown Settings")]
    [Tooltip("Starting time in seconds for countdown")]
    [SerializeField] private int Seconds = 300; // set in Inspector

    private float remainingTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingTime = Mathf.Max(0, Seconds + 1); // +1 to account for immediate countdown
        UpdateTimerText();
    }

    void OnEnable()
    {
        GameManager.OnPauseChanged += HandlePauseChanged;
    }

    void OnDisable()
    {
        GameManager.OnPauseChanged -= HandlePauseChanged;
    }

    private void HandlePauseChanged(bool paused)
    {
        Paused = paused;
    }

    void Update()
    {
        if (GameManager.Paused) return;
        if (GameManager.GameOver) return;
        if (GameManager.howToPlay) return;

        if (remainingTime <= 0f) return; // already finished

        // Use unscaledDeltaTime to count real seconds irrespective of timeScale.
        remainingTime -= Time.unscaledDeltaTime;
        if (remainingTime < 0f) remainingTime = 0f;

        int totalSeconds = Mathf.FloorToInt(remainingTime);
        if (totalSeconds != lastDisplayedSeconds)
        {
            lastDisplayedSeconds = totalSeconds;
            UpdateTimerText();

            // Once timer reaches zero... DO SOMETHING
            if (totalSeconds == 0)
            {
                GameManager.GameOver = true;
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
