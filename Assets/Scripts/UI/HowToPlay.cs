using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject howToPlayMenu;
    void Start()
    {
        if (GameManager.firstTime)
        {
            howToPlayMenu.SetActive(true);
            GameManager.howToPlay = true;
        }
        else 
        {
            howToPlayMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            finishReading();
        }
    }

    void finishReading() 
    {
        howToPlayMenu.SetActive(false);
        GameManager.firstTime = false;
        GameManager.howToPlay = false;
    }
}
