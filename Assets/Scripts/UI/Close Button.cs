using Unity.VisualScripting;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public HowToPlay howToPlay;
    public GameObject pauseMenu;

    public void OnMouseDown()
    {
        GameManager.howToPlay = false;
        pauseMenu.SetActive(true);
        Debug.Log("yippee");
    }
}
