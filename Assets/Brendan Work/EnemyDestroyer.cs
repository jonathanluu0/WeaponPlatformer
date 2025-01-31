using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private float leftScreenEdge;

    void Start()
    {
        // **Find the left edge of the screen**
        leftScreenEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 2f; // Extra buffer
    }

    void Update()
    {
        // **Destroy enemy only after it fully leaves the screen**
        if (transform.position.x < leftScreenEdge)
        {
            Destroy(gameObject);
        }
    }
}
