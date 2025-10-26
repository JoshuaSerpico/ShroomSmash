using TMPro;
using UnityEngine;

public class TopScoreText : MonoBehaviour
{
    public TMP_Text scoreText;
    private void Update()
    {
        scoreText.text = PlayerStats.Instance.HighScore.ToString();
    }
}
