using System.Collections;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    public float speedMultiplier = 1.5f; // How much to speed up the floor
    public float duration = 5f; // Duration of the speed boost

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FloorGenerator floor = FindObjectOfType<FloorGenerator>();

            if (floor != null)
            {
                StartCoroutine(ApplySpeedBoost(floor));
            }

            Destroy(gameObject); // Remove the power-up after activation
        }
    }

    private IEnumerator ApplySpeedBoost(FloorGenerator floor)
    {
        Debug.Log("Speed Boost Activated!");

        // **Increase floor scroll speed**
        float originalScrollSpeed = floor.scrollSpeed;
        floor.scrollSpeed *= speedMultiplier;

        // **Wait for duration**
        yield return new WaitForSeconds(duration);

        // **Revert floor scroll speed to normal**
        floor.scrollSpeed = originalScrollSpeed;

        Debug.Log("Speed Boost Ended");
    }
}