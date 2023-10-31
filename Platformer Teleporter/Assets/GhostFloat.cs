using UnityEngine;

public class GhostFloating : MonoBehaviour
{
    public float floatSpeed = 1.0f;   // Speed of the bobbing effect
    public float floatHeight = 0.5f;  // Height of the bobbing effect
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position based on a sine wave for the floating effect
        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Update the ghost's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
