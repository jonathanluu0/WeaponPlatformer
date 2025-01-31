using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    private float leftScreenEdge;

    private Collider2D damageTrigger; // **Trigger for damaging player**
    private Collider2D solidCollider; // **Solid collider for ground collision**

    void Start()
    {
        leftScreenEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 2f;

        // **Get colliders**
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            if (col.isTrigger)
            {
                damageTrigger = col; // Assign trigger collider
            }
            else
            {
                solidCollider = col; // Assign solid collider
            }
        }

        if (damageTrigger == null)
        {
            Debug.LogWarning(gameObject.name + " is missing a trigger collider!");
        }

        if (solidCollider == null)
        {
            Debug.LogWarning(gameObject.name + " is missing a solid collider!");
        }
    }

    void Update()
    {
        if (transform.position.x < leftScreenEdge)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
