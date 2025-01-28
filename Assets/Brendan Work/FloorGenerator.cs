using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject floorPrefab; // Assign your floor prefab
    public float floorWidth = 10f; // Width of each floor segment
    public float generationOffset = 15f; // How far ahead to generate floors
    public float floorSpawnSpeed = 5f; // Speed at which the floors move

    private float lastGeneratedX = 0f; // Track the last generated floor's X position
    private float generationThreshold = 0f; // Track the X position for generating new floors

    void Start()
    {
        // Generate initial floor segments
        for (int i = 0; i < 3; i++)
        {
            SpawnFloor(i * floorWidth);
        }

        lastGeneratedX = floorWidth * 2; // Set the position of the last floor segment
        generationThreshold = lastGeneratedX;
    }

    void Update()
    {
        // Move all floors to simulate side-scrolling
        MoveFloors();

        // Continuously generate floors ahead of the camera
        if (Camera.main.transform.position.x + generationOffset > generationThreshold)
        {
            SpawnFloor(generationThreshold);
            generationThreshold += floorWidth; // Update the threshold for the next floor
        }
    }

    void SpawnFloor(float xPosition)
    {
        Vector3 spawnPosition = new Vector3(xPosition, -2f, 0); // Adjust Y for your floor height
        Instantiate(floorPrefab, spawnPosition, Quaternion.identity);
    }

    void MoveFloors()
    {
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");

        foreach (GameObject floor in floors)
        {
            floor.transform.Translate(Vector3.left * floorSpawnSpeed * Time.deltaTime);

            // Destroy the floor when it's far off-screen
            if (floor.transform.position.x < Camera.main.transform.position.x - 20f)
            {
                Destroy(floor);
            }
        }
    }
}
