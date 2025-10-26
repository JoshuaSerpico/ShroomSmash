using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        FindAnyObjectByType<SceneLoader>().LoadScene("Play");
    }
}
