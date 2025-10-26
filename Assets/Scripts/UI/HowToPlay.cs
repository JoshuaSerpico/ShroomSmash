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
        if (GameManager.howToPlay) 
        {
            howToPlayMenu.SetActive(true);
        }
        else
        {
            howToPlayMenu.SetActive(false);
        }
    }
}
