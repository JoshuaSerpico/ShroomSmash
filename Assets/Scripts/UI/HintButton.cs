using UnityEngine;

public class HintButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public void onClick() 
    {
        GameManager.howToPlay = true;
        pauseMenu.SetActive(false);
    }
}
