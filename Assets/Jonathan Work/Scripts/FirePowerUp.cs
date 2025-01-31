using System.Collections;
using UnityEngine;

public class FirePowerUp : MonoBehaviour
{
    public float speedIncrease = 1.5f;  // Speed multiplier (e.g., 50% more speed)
    public float powerUpDuration = 5f;  // Duration of power-up effect

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detect if the slime collides with a power-up object
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); // Get PlayerController component
            if (playerController != null)
            {
                playerController.IncreaseSpeed(speedIncrease, powerUpDuration);
            }

            // Destroy the power-up object after collision
            Destroy(gameObject);
        }
    }
}