using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed of background movement
    public GameObject backgroundPrefab; // Prefab to spawn a new background
    private float backgroundWidth; // Width of the background
    private bool spawnedNext = false; // Prevents multiple spawns

    void Start()
    {
        // Get the background width dynamically
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            backgroundWidth = spriteRenderer.bounds.size.x;
        }
        else
        {
            Debug.LogError("ScrollingBackground: No SpriteRenderer found on " + gameObject.name);
        }
    }

    void Update()
    {
        // Move the background to the left
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Spawn new background when current one is halfway off-screen
        if (!spawnedNext && transform.position.x < Camera.main.transform.position.x - (backgroundWidth / 2))
        {
            SpawnNewBackground();
            spawnedNext = true;
        }

        // Destroy the background once it's fully off-screen
        if (transform.position.x < Camera.main.transform.position.x - backgroundWidth)
        {
            Destroy(gameObject);
        }
    }

    void SpawnNewBackground()
    {
        // Instantiate a new background ahead
        Vector3 newPosition = new Vector3(transform.position.x + backgroundWidth * 2, transform.position.y, transform.position.z);
        Instantiate(backgroundPrefab, newPosition, Quaternion.identity);
    }
}
