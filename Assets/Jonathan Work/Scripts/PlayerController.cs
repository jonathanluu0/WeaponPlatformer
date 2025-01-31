using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Automatic forward speed
    public float jumpForce = 10f; // Jump force for jumping
    private int jumpCount = 0; // Track how many times the player has jumped
    public int maxJumps = 2; // Maximum number of jumps allowed (double jump)
    public bool canDestroyEnemies = false;

    private float originalMoveSpeed; // Store the original move speed

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed; // Store the original move speed
    }

    void Update()
    {
        HandleJump();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jump count when touching a surface
        jumpCount = 0;
        if (collision.gameObject.CompareTag("Enemy")) {
            if (canDestroyEnemies) { 
                Destroy(collision.gameObject);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
        
    }

    // Method to increase speed
    public void IncreaseSpeed(float multiplier, float duration)
    {
        StartCoroutine(SpeedBoost(multiplier, duration));
    }

    private IEnumerator SpeedBoost(float multiplier, float duration)
    {
        moveSpeed *= multiplier; // Increase the speed
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed; // Reset the speed
    }
}