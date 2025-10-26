using UnityEngine;

public class HoleController : MonoBehaviour
{
    [Header("Mushroom Settings")]
    [SerializeField] private GameObject[] mushroomPrefabs; // List of prefabs to pick from
    [SerializeField] private int spawnDelayBeatsMin = 5; // Minimum beats to wait before spawning
    [SerializeField] private int spawnDelayBeatsMax = 15; // Maximum beats to wait before spawning

    private bool mushroomExists = false;
    private int beatsUntilNextSpawn; // Number of beats to wait before spawning again

    private bool Paused = false;

    void OnEnable()
    {
        Debug.Log($"HoleController enabled on {gameObject.name}");
        BPMController.OnBeat += OnBeat;
        GameManager.OnPauseChanged += HandlePauseChanged;
        beatsUntilNextSpawn = Random.Range(10, 31); // Initial delay between 30 and 60 beats
    }

    void OnDisable()
    {
        BPMController.OnBeat -= OnBeat;
        GameManager.OnPauseChanged -= HandlePauseChanged;
    }

    private void OnBeat()
    {
        // if game is paused, do nothing
        if (Paused) return;
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

    private void HandlePauseChanged(bool paused)
    {
        Paused = paused;
    }

    private void SpawnMushroom()
    {
        if(GameManager.Paused) return;
        if(GameManager.howToPlay) return;
        if(GameManager.GameOver) return;

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
            mushroomGO.GetComponent<MeshRenderer>().sortingOrder = 21;

            var skeletonAnimation = mushroomGO.GetComponent<Spine.Unity.SkeletonAnimation>();
            var skin = UnityEngine.Random.Range(1, 17);
            skeletonAnimation.initialSkinName = skin.ToString();
            skeletonAnimation.Initialize(true);
            skeletonAnimation.AnimationState.SetAnimation(0, "idle", true);

            // Mark that a mushroom exists
            mushroomExists = true;

            // Get its controller and subscribe to the event
            MushroomController mushroom = mushroomGO.GetComponent<MushroomController>();
            if (mushroom != null)
            {
                mushroom.OnDeath += HandleMushroomDeath;
                mushroom.skin = skin;
            }
        sfxManager.Instance.audioSource.clip = sfxManager.Instance.sfxClips[Random.Range(2, 5)];
        sfxManager.Instance.audioSource.PlayOneShot(sfxManager.Instance.audioSource.clip);
    }

    private void HandleMushroomDeath(MushroomController mushroom)
    {
        mushroom.OnDeath -= HandleMushroomDeath; // Unsubscribe for safety
        mushroomExists = false; // Allow the next spawn

        // Set a random delay between 10 and 30 beats (inclusive) before next spawn
        beatsUntilNextSpawn = Random.Range(spawnDelayBeatsMin, spawnDelayBeatsMax + 1);
    }
}