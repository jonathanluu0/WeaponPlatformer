using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab here
    public float spawnInterval = 2f; // Time between spawns
    public float spawnHeight = 3f; // Random vertical range for spawning
    public float spawnXPosition = 10f; // Spawn point on the X-axis
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
        float randomY = Random.Range(-spawnHeight, spawnHeight);
        Vector3 spawnPosition = new Vector3(spawnXPosition, randomY, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
