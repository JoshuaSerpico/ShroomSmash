using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        FindAnyObjectByType<SceneLoader>().LoadScene("Play");
    }
}
