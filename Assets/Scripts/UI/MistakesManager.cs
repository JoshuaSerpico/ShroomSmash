using UnityEngine;

public class MistakesManager : MonoBehaviour
{
    public int mistakeCount = 0;

    [SerializeField] private GameObject mistake1UI;
    [SerializeField] private GameObject mistake2UI;
    [SerializeField] private GameObject mistake3UI;

    void OnEnable()
    {
        MushroomController.OnMistake += HandleMistake;
    }

    void OnDisable()
    {
        MushroomController.OnMistake -= HandleMistake;
    }

    private void Start()
    {
        mistakeCount = 0;
        updateMistakeUI();
    }

    private void HandleMistake(bool isMistake)
    {
        if (isMistake)
        {
            mistakeCount++;
            updateMistakeUI();
        }
    }

    private void updateMistakeUI()
    {
        // Switch case for mistakes 1 2 and 3 to update the UI accordingly
        switch (mistakeCount)
        {
            case 0:
                // No mistakes, hide all UI
                mistake1UI.SetActive(false);
                mistake2UI.SetActive(false);
                mistake3UI.SetActive(false);
                break;
            case 1:
                // Update UI for first mistake
                mistake1UI.SetActive(true);
                break;
            case 2:
                // Update UI for second mistake
                mistake2UI.SetActive(true);
                break;
            case 3:
                // Update UI for third mistake
                mistake3UI.SetActive(true);
                Debug.LogWarning("End Game Condition Reached: Implement end-of-game logic here.");
                break;
            default:
                // Handle more than three mistakes if necessary
                break;
        }
    }
}
