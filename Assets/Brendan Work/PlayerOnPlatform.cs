using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingFloor"))
        {
            // Make the player a child of the moving floor
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingFloor"))
        {
            // Remove the player from the moving floor
            transform.parent = null;
        }
    }
}
