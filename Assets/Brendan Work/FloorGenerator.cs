using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject floorPrefab; // Assign your floor prefab
    public float floorWidth = 10f; // Width of each floor segment
    public float generationOffset = 15f; // How far ahead to generate floors
    private Transform playerTransform; // Reference to the player

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Generate initial floor segments
        for (int i = 0; i < 3; i++)
        {
            SpawnFloor(i * floorWidth);
        }
    }

    void Update()
    {
        // Continuously generate floors ahead of the player
        if (playerTransform.position.x + generationOffset > transform.position.x)
        {
            SpawnFloor(transform.position.x + floorWidth);
        }
    }

    void SpawnFloor(float xPosition)
    {
        Vector3 spawnPosition = new Vector3(xPosition, -2f, 0); // Adjust Y for your floor height
        Instantiate(floorPrefab, spawnPosition, Quaternion.identity);

        // Update the generator position
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
