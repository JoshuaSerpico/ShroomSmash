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
        if (!GameManager.paused)
        {
            GameManager.paused = true;
            pauseMenu.SetActive(true);
            //implement pausing, not sure how to with the bpm settings
        }
        else 
        {
            GameManager.paused = false;
            pauseMenu.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        onClick();
    }
}
