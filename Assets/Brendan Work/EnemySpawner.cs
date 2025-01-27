using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab
    public float spawnInterval = 2f; // Time between enemy spawns
    public float spawnHeightMin = -2f; // Minimum spawn height
    public float spawnHeightMax = 2f; // Maximum spawn height
    public float spawnOffsetX = 10f; // How far off-screen enemies spawn
    public float enemySpeed = 5f; // Speed at which enemies move left

    private float timer = 0f;

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
        // Randomize the spawn height
        float randomY = Random.Range(spawnHeightMin, spawnHeightMax);

        // Spawn the enemy off-screen to the right
        Vector3 spawnPosition = new Vector3(Camera.main.transform.position.x + spawnOffsetX, randomY, 0);

        // Instantiate the enemy
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Set the enemy's movement
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = enemy.AddComponent<Rigidbody2D>();
        }
        rb.isKinematic = true; // Ensures physics don’t interfere
        rb.velocity = new Vector2(-enemySpeed, 0); // Move left at a constant speed
    }
}
