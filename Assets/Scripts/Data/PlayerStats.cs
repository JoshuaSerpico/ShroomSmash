using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }

    public void Awake()
    {
        // Singleton check
        if (Instance == null)
        {
            Instance = this;
            LoadStats();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int amount)
    {
        CurrentScore = amount;
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            SaveHighScore();
        }
    }

    #region Persistent Storage
    private void SaveHighScore() => PlayerPrefs.SetInt("HighScore", HighScore);
    private void LoadStats()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        CurrentScore = 0;
    }
    #endregion
}
