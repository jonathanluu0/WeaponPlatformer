using System.Collections;
using UnityEngine;

public class FirePowerUp : MonoBehaviour
{
    public float speedIncrease = 1.5f;  
    public float powerUpDuration = 5f;  

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Speed Power Up triggered!");
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); 
            if (playerController != null)
            {
                playerController.IncreaseSpeed(speedIncrease, powerUpDuration);
            }

            // Destroy the power-up object after collision
            Destroy(gameObject);
        }
    }
}