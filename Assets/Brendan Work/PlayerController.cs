using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // Adjust for jumping power
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Use Space key to jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
