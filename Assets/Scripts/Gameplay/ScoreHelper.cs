using UnityEngine;
using TMPro;

public class ScoreHelper : MonoBehaviour
{
    public static ScoreHelper Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private TMP_Text scoreText;

    private int currentScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Reset score when entering the play scene
        currentScore = 0;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        // Update UI
        UpdateScoreUI();

        // Update global PlayerStats (persistent)
        PlayerStats.Instance.UpdateScore(currentScore);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"{currentScore}";
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
        PlayerStats.Instance.UpdateScore(0);
    }
}
