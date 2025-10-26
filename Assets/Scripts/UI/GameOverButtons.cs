using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.transform.name.Equals("menu_button_0"))
        {
            SceneManager.LoadScene("Main Menu");
        }
        else 
        {
            FindAnyObjectByType<SceneLoader>().LoadScene("Play");
        }
        GameManager.GameOver = false;
    }
}
