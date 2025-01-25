using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    public float offscreenX = -15f;

    void Update()
    {
        if (transform.position.x < offscreenX)
        {
            Destroy(gameObject);
        }
    }
}
