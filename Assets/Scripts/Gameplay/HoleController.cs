using UnityEngine;

public class HoleController : MonoBehaviour
{
    [Header("Mushroom Settings")]
    [SerializeField] private GameObject[] mushroomPrefabs; // List of prefabs to pick from

    private bool mushroomExists = false;
    private int beatsUntilNextSpawn; // Number of beats to wait before spawning again

    void OnEnable()
    {
        Debug.Log($"HoleController enabled on {gameObject.name}");
        BPMController.OnBeat += OnBeat;
        beatsUntilNextSpawn = Random.Range(30, 61); // Initial delay between 30 and 60 beats
    }

    void OnDisable()
    {
        BPMController.OnBeat -= OnBeat;
    }

    private void OnBeat()
    {
        // If a mushroom exists, do nothing
        if (mushroomExists) return;

        // If we're waiting for beats before spawning, decrement and wait
        if (beatsUntilNextSpawn > 0)
        {
            beatsUntilNextSpawn--;
            return;
        }

        Debug.Log($"Spawning mushroom at {gameObject.name}");
        SpawnMushroom();
    }

    private void SpawnMushroom()
    {
        if (mushroomPrefabs.Length == 0)
        {
            Debug.LogWarning("No mushroom prefabs assigned to " + gameObject.name);
            return;
        }

        // Pick a random mushroom prefab
        GameObject prefab = mushroomPrefabs[Random.Range(0, mushroomPrefabs.Length)];

        // Instantiate it as a child of this hole
        GameObject mushroomGO = Instantiate(prefab, transform.position, Quaternion.identity, transform);

        // Set mushroom animations and skins
        mushroomGO.transform.localScale = new Vector3(100f, 100f, 1);
        mushroomGO.transform.localPosition += new Vector3(-135f, -30, 0);
        mushroomGO.GetComponent<MeshRenderer>().sortingOrder = 1;

        var skeletonAnimation = mushroomGO.GetComponent<Spine.Unity.SkeletonAnimation>();
        skeletonAnimation.initialSkinName = UnityEngine.Random.Range(1, 17).ToString();
        skeletonAnimation.Initialize(true);
        skeletonAnimation.AnimationState.SetAnimation(0, "idle", true);

        // Mark that a mushroom exists
        mushroomExists = true;

        // Get its controller and subscribe to the event
        MushroomController mushroom = mushroomGO.GetComponent<MushroomController>();
        if (mushroom != null)
        {
            mushroom.OnDeath += HandleMushroomDeath;
        }
    }

    private void HandleMushroomDeath(MushroomController mushroom)
    {
        mushroom.OnDeath -= HandleMushroomDeath; // Unsubscribe for safety
        mushroomExists = false; // Allow the next spawn

        // Set a random delay between 10 and 30 beats (inclusive) before next spawn
        beatsUntilNextSpawn = Random.Range(10, 31);
    }
}