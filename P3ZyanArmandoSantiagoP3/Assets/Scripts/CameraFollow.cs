using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Drag your player here
    public float smoothSpeed = 0.125f; // Higher = faster camera
    public Vector3 offset = new Vector3(0, 0, -10); // Keeps camera at a distance

    void LateUpdate() // LateUpdate runs after the player moves
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            // Smoothly slide from current position to player position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}