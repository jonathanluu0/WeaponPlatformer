using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Automatic forward speed
    public float jumpForce = 10f; // Jump force for jumping
    private int jumpCount = 0; // Track how many times the player has jumped
    public int maxJumps = 2; // Maximum number of jumps allowed (double jump)

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleJump();
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        // Move the player forward automatically
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            Jump();
            jumpCount++;
        }
    }

    private void Jump()
    {
        // Apply vertical velocity for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetTrigger("Jump");
    }

    private void UpdateAnimations()
    {
        // Update animation parameters if needed
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jump count when touching a surface
        jumpCount = 0;
    }
}
