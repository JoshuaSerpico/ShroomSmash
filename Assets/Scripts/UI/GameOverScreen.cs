using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreen;

    void Update()
    {
        if (GameManager.GameOver)
        {
            gameOverScreen.SetActive(true);
        }
        else 
        {
            gameOverScreen.SetActive(false);
        }
    }
}
