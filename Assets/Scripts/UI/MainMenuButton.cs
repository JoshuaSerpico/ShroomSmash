using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void onClick() 
    {
        GameManager.paused = false;
        SceneManager.LoadScene("Main Menu");
    }
}
