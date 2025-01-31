using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnRate = 1.5f; // Minimum time between spawns
    public float maxSpawnRate = 3.5f; // Maximum time between spawns
    public float enemySpeed = 2f;

    public float spawnYMin = -6f; 
    public float spawnYMax = 4f;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + Random.Range(minSpawnRate, maxSpawnRate); // **Randomize next spawn time**
        }
    }

    void SpawnEnemy()
    {
        float screenRightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 2f;
        float randomY = Random.Range(spawnYMin, spawnYMax);

        Vector3 spawnPosition = new Vector3(screenRightEdge, randomY, 0);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * enemySpeed;
        }

        enemy.AddComponent<EnemyDestroyer>();
    }
}
