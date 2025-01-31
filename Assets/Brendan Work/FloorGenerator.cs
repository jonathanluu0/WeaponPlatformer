using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject floorPrefab; // Floor prefab reference
    public float floorWidth = 10f; // Width of each floor segment
    public float generationOffset = 15f; // Distance ahead to generate floors
    private Transform cameraTransform; // Reference to the camera
    private float lastFloorX; // Tracks the last spawned floor position

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastFloorX = cameraTransform.position.x - floorWidth; // Start floor before camera

        // Generate initial floor segments
        for (int i = 0; i < 3; i++)
        {
            SpawnFloor(lastFloorX + (i * floorWidth));
        }
    }

    void Update()
    {
        // Update floor to stay at the bottom of the camera
        float floorY = Camera.main.transform.position.y - Camera.main.orthographicSize + 0.5f;
        transform.position = new Vector3(transform.position.x, floorY, transform.position.z);

        // Generate new floors ahead of the camera
        if (cameraTransform.position.x + generationOffset > lastFloorX)
        {
            SpawnFloor(lastFloorX + floorWidth);
        }
    }

    void SpawnFloor(float xPosition)
    {
        float floorY = Camera.main.transform.position.y - Camera.main.orthographicSize + 0.5f; // Align with camera bottom
        Vector3 spawnPosition = new Vector3(xPosition, floorY, 0);
        Instantiate(floorPrefab, spawnPosition, Quaternion.identity);
        lastFloorX = xPosition;
    }
}
