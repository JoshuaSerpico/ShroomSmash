using UnityEngine;

public class HoleController : MonoBehaviour
{
    private bool canSpawn = true;
    void OnEnable()
    {
        BPMController.OnBeat += OnBeat;
    }

    void OnDisable()
    {
        BPMController.OnBeat -= OnBeat;
    }

    private void OnBeat()
    {
        if (!canSpawn) return;

        // Logic to decide if a mushroom should spawn this beat
        SpawnMushroom();
    }

    private void SpawnMushroom()
    {
        // Implement mushroom spawning logic here
        Debug.Log("Mushroom Spawned!");
    }
}
