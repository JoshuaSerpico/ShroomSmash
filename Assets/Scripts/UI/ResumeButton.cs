using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public void onClick() 
    {
        GameManager.paused = false;
        pauseMenu.SetActive(false);
        //implement unpausing
    }
}
