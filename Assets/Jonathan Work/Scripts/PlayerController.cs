using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement Settings")]
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    private int jumpCount = 0; 
    public int maxJumps = 2; 
    public bool canDestroyEnemies = false;

    [Header("Shield Settings")]
    private bool isShieldActive = false; 
    private bool isSpeedBoostActive = false;
    private int shieldLives = 0; 

    [Header("Audio")]
    private AudioSource audioSource;
    public AudioClip jumpSound; 
    public AudioClip hitEnemySound;

    private float originalMoveSpeed; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        originalMoveSpeed = moveSpeed; 
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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
         if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (hitEnemySound != null)
            {
                audioSource.PlayOneShot(hitEnemySound);
            }
            // If speed boost is active, destroy the enemy
            if (isSpeedBoostActive)
            {
                Destroy(collision.gameObject);
            }
            // If shield is active, destroy the enemy and reduce shield lives
            else if (isShieldActive && shieldLives > 0)
            {
                Destroy(collision.gameObject);
                shieldLives--;

                if (shieldLives <= 0)
                {
                    isShieldActive = false;
                }
            }
            // If neither shield nor speed boost is active, reload the scene
            else if (!isShieldActive && !isSpeedBoostActive)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ActivateShield(int lives)
    {
        isShieldActive = true;
        shieldLives = lives;
        Debug.Log("Shield Activated! Lives: " + shieldLives);
    }

    public void IncreaseSpeed(float multiplier, float duration)
    {
        if (!isSpeedBoostActive) // Prevent overlapping speed boosts
        {
            isSpeedBoostActive = true;
            StartCoroutine(SpeedBoost(multiplier, duration));
        }
    }

    private IEnumerator SpeedBoost(float multiplier, float duration)
    {
        moveSpeed *= multiplier; 
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed; 
        isSpeedBoostActive = false; // Reset the flag after the duration ends
    }
}