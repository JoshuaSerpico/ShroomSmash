using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static bool paused;
    public static bool firstTime;
    public static bool howToPlay;
    private void Awake()
    {
        // Singleton check
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        paused = false;
        howToPlay = false;

        firstTime = false;
        //swap this to use playerPrefs if we want this to persist across sessions
        //change back to true when you go back to working
    }
}
