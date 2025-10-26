using UnityEngine;
using System;
using Spine.Unity;
using System.Collections;

public class MushroomController : MonoBehaviour
{
    public event Action<MushroomController> OnDeath;

    [Header("Settings")]
    [Tooltip("# of Beats until Mushroom goes away")]
    [SerializeField] private int StayForNumBeats = 10;
    [SerializeField] private int Score = 100;
    [SerializeField] private bool Bad = false;
    public int skin;
    [SerializeField] private bool leaving; // to not be able to click them as they leave, it causes funky animation stuff

    private int timer = 0;
    SkeletonAnimation skeletonAnimation;

    void OnEnable()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        BPMController.OnBeat += OnBeat;
        timer = 0; // Reset timer when enabled
        leaving = false;
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
        if (!leaving)
        {
            if (skin > 9)
            {
                Score *= -1;
                Bad = true;
            }
            ScoreHelper.Instance.AddScore(Score);

            // IF BAD MUSHROOM, ADD MISTAKE
            if (Bad)
            {
                skeletonAnimation.AnimationState.SetAnimation(0, "death-bad", false);
            }
            else
            {
                skeletonAnimation.AnimationState.SetAnimation(0, "death-good", false);
            }
            skeletonAnimation.AnimationState.Complete += animationComplete;
            // DEATH ANIMATION HERE

            Die();
        }
    }

    private void Die()
    {
        leaving = true;
        OnDeath?.Invoke(this); // Notify listeners that this mushroom has died
        skeletonAnimation.AnimationState.Complete += animationComplete;
    }

    private void animationComplete(Spine.TrackEntry trackEntry) 
    {
        trackEntry.Complete -= animationComplete;

        Destroy(gameObject);
    }
}
