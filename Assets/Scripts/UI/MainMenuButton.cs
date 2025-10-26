using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void onClick() 
    {
        GameManager.Instance.TogglePause();
        SceneManager.LoadScene("Main Menu");
    }
}
