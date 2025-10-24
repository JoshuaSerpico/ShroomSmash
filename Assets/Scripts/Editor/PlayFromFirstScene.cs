using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class PlayFromStartScene
{
    private const string MenuPath = "Play From Start/Toggle %#L";
    private const string PrefKey = "PlayFromStartSceneEnabled";
    private const string StartScenePath = "Assets/Scenes/Loading.unity";

    // Key used to store which scene was open when hitting Play
    private const string LastSceneKey = "PlayFromStart_LastScenePath";

    static PlayFromStartScene()
    {
        EditorApplication.delayCall += () =>
        {
            bool enabled = EditorPrefs.GetBool(PrefKey, true);
            Menu.SetChecked(MenuPath, enabled);
        };

        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    [MenuItem(MenuPath)]
    public static void Toggle()
    {
        bool enabled = !EditorPrefs.GetBool(PrefKey, true);
        EditorPrefs.SetBool(PrefKey, enabled);
        Menu.SetChecked(MenuPath, enabled);
        Debug.Log($"Play From Start is now {(enabled ? "Enabled" : "Disabled")}");
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            bool enabled = EditorPrefs.GetBool(PrefKey, true);

            // Save the currently open scene path
            string activeScenePath = EditorSceneManager.GetActiveScene().path;
            EditorPrefs.SetString(LastSceneKey, activeScenePath);

            // Always start from Loading scene
            var loadingScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(StartScenePath);
            if (loadingScene != null)
            {
                EditorSceneManager.playModeStartScene = loadingScene;
            }
            else
            {
                Debug.LogWarning($"PlayFromStart: Missing scene at {StartScenePath}");
            }
        }
        else if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // If the toggle is OFF, we’ll jump back to the originally open scene after loading
            if (!EditorPrefs.GetBool(PrefKey, true))
            {
                string targetScene = EditorPrefs.GetString(LastSceneKey);
                if (!string.IsNullOrEmpty(targetScene))
                {
                    // Run this inside play mode
                    UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(System.IO.Path.GetFileNameWithoutExtension(targetScene));
                }
            }
        }
    }
}