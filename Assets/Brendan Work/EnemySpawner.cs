using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab
    public float spawnInterval = 2f; // Time between spawns
    public float spawnHeight = 3f; // Random vertical range for spawning
    public float spawnOffsetX = 10f; // Distance from the camera's edge for spawning

    private float timer = 0f;
    private Transform movingFloor; // Reference to the moving floor

    void Start()
    {
        // Find the moving floor (make sure it's tagged "MovingFloor")
        movingFloor = GameObject.FindGameObjectWithTag("MovingFloor").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Determine the spawn position relative to the moving floor
        float randomY = Random.Range(-spawnHeight, spawnHeight);
        Vector3 spawnPosition = new Vector3(
            movingFloor.position.x + spawnOffsetX, // Off-screen to the right
            movingFloor.position.y + randomY, // Random height
            0
        );

        // Instantiate the enemy and make it a child of the moving floor
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.transform.parent = movingFloor; // Make the enemy follow the floor
    }
}
