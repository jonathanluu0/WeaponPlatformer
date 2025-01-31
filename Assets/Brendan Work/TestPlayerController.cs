using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // Jump strength
    public float gravityScale = 1f; // Gravity multiplier
    public float forwardSpeed = 2.5f; // Auto-moving speed

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;

        // **Move the player to the left side of the screen**
        float leftEdgeX = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x; // 10% from left
        float floorY = Camera.main.transform.position.y - Camera.main.orthographicSize + 1f;
        transform.position = new Vector3(leftEdgeX, floorY, 0);
    }

    void Update()
    {
        // Auto move forward (adjustable speed)
        transform.position += Vector3.right * forwardSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}

