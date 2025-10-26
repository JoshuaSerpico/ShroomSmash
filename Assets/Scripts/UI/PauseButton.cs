using JetBrains.Annotations;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Awake()
    {
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            onClick();
        }
    }

    public void onClick() 
    {
        if (!GameManager.Paused)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
        
        GameManager.Instance.TogglePause();
    }

    private void OnMouseDown()
    {
        onClick();
    }
}
