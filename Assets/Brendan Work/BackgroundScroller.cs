using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetPositionX = -20f;
    public float startPositionX = 20f;

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Reset position when the background is out of bounds
        if (transform.position.x <= resetPositionX)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = startPositionX;
            transform.position = newPosition;
        }
    }
}
