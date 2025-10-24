using UnityEngine;
using System;

public class BPMController : MonoBehaviour
{
    public static BPMController Instance { get; private set; }
    [SerializeField] private float bpm = 120f;
    public float BPM => bpm;

    public static event Action OnBeat; // Global event

    private double beatInterval;
    private double beatTimer;

    void Awake()
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

        UpdateBeatInterval();
        beatTimer = AudioSettings.dspTime + beatInterval; // Start timer aligned with audio system
    }

    void Update()
    {
        double dspTime = AudioSettings.dspTime;

        // Trigger beat if passed the scheduled time
        if (dspTime >= beatTimer)
        {
            OnBeat?.Invoke(); // Trigger the beat event
            beatTimer += beatInterval; // Schedule next beat
        }
    }

    public void SetBPM(float newBPM)
    {
        bpm = newBPM;
        UpdateBeatInterval();
    }

    private void UpdateBeatInterval() => beatInterval = 60f / bpm;

#if UNITY_EDITOR // For testing purposes in the editor
    private void OnValidate() => UpdateBeatInterval();
#endif
}