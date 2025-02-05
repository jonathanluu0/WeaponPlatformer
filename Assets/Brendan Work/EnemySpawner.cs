using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnRate = 1.5f;
    public float maxSpawnRate = 3.5f;
    public float enemySpeed = 2f;

    private float nextSpawnTime;
    private List<GameObject> floors = new List<GameObject>(); // Track floors

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
        }

        // Keep track of generated floors
        UpdateFloorList();
    }

    void SpawnEnemy()
    {
        GameObject floor = GetRandomFloor();
        if (floor == null) return; // No floor available

        float screenRightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 2f;
        float floorY = floor.transform.position.y + 0.5f; // Spawn slightly above floor

        Vector3 spawnPosition = new Vector3(screenRightEdge, floorY, 0);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * enemySpeed;
        }
    }

    GameObject GetRandomFloor()
    {
        if (floors.Count == 0) return null;

        return floors[Random.Range(0, floors.Count)];
    }

    void UpdateFloorList()
    {
        floors.Clear();
        foreach (GameObject floor in GameObject.FindGameObjectsWithTag("Floor"))
        {
            if (floor.transform.position.x > Camera.main.transform.position.x - 10f)
            {
                floors.Add(floor);
            }
        }
    }
}
