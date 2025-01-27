using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health
    private int currentHealth; // Current health
    public GameObject[] healthIndicators; // Array of health indicator GameObjects

    void Start()
    {
        currentHealth = maxHealth; // Set starting health
        UpdateHealthUI(); // Update the health display
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1); // Deal 1 damage on contact
            Destroy(collision.gameObject); // Destroy the enemy after contact
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); // Call the death function if health is zero
        }

        UpdateHealthUI(); // Update the health display
    }

    void UpdateHealthUI()
    {
        // Disable health indicators based on current health
        for (int i = 0; i < healthIndicators.Length; i++)
        {
            healthIndicators[i].SetActive(i < currentHealth);
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // Add death behavior here (e.g., restart level, game over screen)
    }
}
