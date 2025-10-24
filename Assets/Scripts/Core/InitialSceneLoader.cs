using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "Main Menu";

    private void Start()
    {
        StartCoroutine(LoadFirstScene());
    }

    private IEnumerator LoadFirstScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!op.isDone)
        {
            yield return null;
        }
    }
}
