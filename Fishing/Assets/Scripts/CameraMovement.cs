using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // The target to follow (your hook)
    public float smoothSpeed = 5f; // How quickly the camera follows the target
    public float maxX = 10f; // Maximum X-coordinate for the camera
    public float maxY = 5f; // Maximum Y-coordinate for the camera

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not set for CameraFollow script.");
            return;
        }

        // Get the current camera position
        Vector3 currentPosition = transform.position;

        // Create a new position with the target's X and Y values, clamped within the specified limits
        Vector3 newPosition = new Vector3(Mathf.Clamp(target.position.x, -maxX, maxX),
                                          Mathf.Clamp(target.position.y, -maxY, maxY),
                                          currentPosition.z);

        // Smoothly interpolate between the current position and the new position
        Vector3 smoothedPosition = Vector3.Lerp(currentPosition, newPosition, smoothSpeed * Time.deltaTime);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;
    }
}
