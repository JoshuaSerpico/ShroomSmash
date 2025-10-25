using UnityEngine;
using System;

public class MushroomController : MonoBehaviour
{
    public event Action<MushroomController> OnDeath;

    [Header("Settings")]
    [Tooltip("# of Beats until Mushroom goes away")]
    [SerializeField] private int StayForNumBeats = 10;
    [SerializeField] private int Score = 100;

    private int timer = 0;

    void OnEnable()
    {
        BPMController.OnBeat += OnBeat;
        timer = 0; // Reset timer when enabled
    }

    void OnDisable()
    {
        BPMController.OnBeat -= OnBeat;
    }

    private void OnBeat()
    {
        timer++;

        // Check if the mushroom should die
        if (timer >= StayForNumBeats)
        {
            Die();
        }
    }
    
    private void OnMouseDown()
    {
        // UPDATE SCORE HERE
        Die();
    }

    private void Die()
    {
        OnDeath?.Invoke(this); // Notify listeners that this mushroom has died
        Destroy(gameObject);
    }
}
