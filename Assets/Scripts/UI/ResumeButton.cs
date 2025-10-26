using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public void onClick() 
    {
        GameManager.Instance.TogglePause();
        pauseMenu.SetActive(false);
        //implement unpausing
    }
}
