using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject floorPrefab; // Assign your floor prefab
    public float floorWidth = 10f; // Width of each floor segment
    public float generationOffset = 15f; // Distance ahead of the camera to spawn floors
    public float despawnOffset = -15f; // Distance behind the camera to despawn floors
    public float scrollSpeed = 5f; // Auto-scroll speed

    private float lastGeneratedX = 0f; // Track the last generated floor's X position

    void Start()
    {
        // Generate initial floor segments
        for (int i = 0; i < 5; i++)
        {
            SpawnFloor(i * floorWidth);
        }

        lastGeneratedX = floorWidth * 4; // Set the last generated X position
    }

    void Update()
    {
        // Move the camera automatically
        MoveCamera();

        // Generate floors ahead of the camera
        while (Camera.main.transform.position.x + generationOffset > lastGeneratedX)
        {
            SpawnFloor(lastGeneratedX);
            lastGeneratedX += floorWidth;
        }

        // Despawn floors that move behind the camera
        DespawnOldFloors();
    }

    void SpawnFloor(float xPosition)
    {
        if (floorPrefab == null)
        {
            Debug.LogError("Floor Prefab is missing! Assign it in the Inspector.");
            return;
        }

        // Ensure the floor spawns at the correct Y position
        float floorY = floorPrefab.transform.position.y; // Use prefab's default Y position
        Vector3 spawnPosition = new Vector3(xPosition, floorY, 0);
        Instantiate(floorPrefab, spawnPosition, Quaternion.identity);
    }

    void DespawnOldFloors()
    {
        // Find all floor objects
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");

        foreach (GameObject floor in floors)
        {
            // Destroy floors that move behind the camera
            if (floor.transform.position.x < Camera.main.transform.position.x + despawnOffset)
            {
                Destroy(floor);
            }
        }
    }

    void MoveCamera()
    {
        // Move the camera at a constant speed to the right
        Camera.main.transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}
