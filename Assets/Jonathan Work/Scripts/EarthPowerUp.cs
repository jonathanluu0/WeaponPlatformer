using System.Collections;
using UnityEngine;

public class EarthPowerUp : MonoBehaviour
{
    public int shieldLives = 3; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.ActivateShield(shieldLives);
            }
            Destroy(gameObject);
        }
    }
}