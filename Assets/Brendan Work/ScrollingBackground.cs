using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed of background movement
    public GameObject backgroundPrefab; // Prefab for new background
    private float backgroundWidth; // Width of the background
    private bool hasSpawnedNext = false; // Prevents multiple spawns

    void Start()
    {
        // Get the width of the background including its scale
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            backgroundWidth = sr.bounds.size.x * transform.localScale.x;
            Debug.Log(gameObject.name + " - Background width: " + backgroundWidth);
        }
        else
        {
            Debug.LogError(gameObject.name + " - ERROR: No SpriteRenderer found!");
        }
    }

    void Update()
    {
        // Move the background to the left at a constant speed
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // **New Spawn Condition - Ensures Proper Timing**
        if (!hasSpawnedNext && transform.position.x <= -backgroundWidth + (scrollSpeed * Time.deltaTime * 2))
        {
            Debug.Log(gameObject.name + " - Triggering SpawnNewBackground()");
            SpawnNewBackground();
            hasSpawnedNext = true;
        }

        // **New Destroy Condition - Ensures No Extra Delay**
        if (transform.position.x <= -backgroundWidth * 1.1f)
        {
            Debug.Log(gameObject.name + " - Destroying self");
            Destroy(gameObject);
        }
    }

    void SpawnNewBackground()
    {
        if (backgroundPrefab == null)
        {
            Debug.LogError(gameObject.name + " - ERROR: No backgroundPrefab assigned!");
            return;
        }

        // **Correct Spawn Position to Avoid Gaps**
        float newX = transform.position.x + backgroundWidth * 2f - (scrollSpeed * Time.deltaTime * 3);
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        GameObject newBackground = Instantiate(backgroundPrefab, newPosition, Quaternion.identity);
        Debug.Log(gameObject.name + " - Spawned new background at: " + newPosition.x);

        // Apply same settings to the new background
        ScrollingBackground newScroll = newBackground.GetComponent<ScrollingBackground>();
        newScroll.scrollSpeed = scrollSpeed;
        newScroll.backgroundPrefab = backgroundPrefab;

        // Reset spawn flag
        newScroll.hasSpawnedNext = false;
    }
}
