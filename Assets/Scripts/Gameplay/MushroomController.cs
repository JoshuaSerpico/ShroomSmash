using UnityEngine;
using System;

public class MushroomController : MonoBehaviour
{
    public event Action<MushroomController> OnDeath;

    [Header("Settings")]
    [Tooltip("# of Beats until Mushroom goes away")]
    [SerializeField] private int StayForNumBeats = 10;
    [SerializeField] private int Score = 100;
    [SerializeField] private bool Bad = false;

    private int timer = 0;

    void OnEnable()
    {
        BPMController.OnBeat += OnBeat;
        timer = 0; // Reset timer when enabled
        // MUSHROOM APPEARS ANIMATION HERE
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
            // MUSHROOM LEAVES ANIMATION HERE
            Die();
        }
    }
    
    private void OnMouseDown() // Called when the mushroom is clicked
    {
        ScoreHelper.Instance.AddScore(Score);

        // IF BAD MUSHROOM, ADD MISTAKE

        // DEATH ANIMATION HERE
        
        Die();
    }

    private void Die()
    {
        OnDeath?.Invoke(this); // Notify listeners that this mushroom has died
        Destroy(gameObject);
    }
}
