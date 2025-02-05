using UnityEngine;
using System.Collections.Generic;

public class FloorGenerator : MonoBehaviour
{
    public GameObject floorPrefab;
    public float floorWidth = 10f; 
    public float generationOffset = 15f; 
    public float scrollSpeed = 2f;

    private Transform cameraTransform;
    private float lastFloorX;
    private Queue<GameObject> floorQueue = new Queue<GameObject>(); // Store active floors

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastFloorX = cameraTransform.position.x - floorWidth;

        for (int i = 0; i < 3; i++)
        {
            SpawnFloor(lastFloorX + (i * floorWidth));
        }
    }

    void Update()
    {
        float floorY = Camera.main.transform.position.y - Camera.main.orthographicSize + 0.5f;
        transform.position = new Vector3(transform.position.x, floorY, transform.position.z);

        MoveFloors();

        // **Spawn new floors sooner when speed increases**
        if (cameraTransform.position.x + generationOffset > lastFloorX - (floorWidth / 2))
        {
            SpawnFloor(lastFloorX + floorWidth);
        }
    }

    void MoveFloors()
    {
        List<GameObject> floorsToRemove = new List<GameObject>();

        foreach (GameObject floor in floorQueue)
        {
            floor.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            if (floor.transform.position.x < cameraTransform.position.x - (generationOffset + floorWidth))
            {
                floorsToRemove.Add(floor);
            }
        }

        // Remove old floors
        foreach (GameObject floor in floorsToRemove)
        {
            floorQueue.Dequeue();
            Destroy(floor);
        }
    }

    void SpawnFloor(float xPosition)
    {
        float floorY = Camera.main.transform.position.y - Camera.main.orthographicSize + 0.5f;
        Vector3 spawnPosition = new Vector3(xPosition, floorY, 0);
        GameObject newFloor = Instantiate(floorPrefab, spawnPosition, Quaternion.identity);

        floorQueue.Enqueue(newFloor);
        lastFloorX = xPosition;
    }
}
