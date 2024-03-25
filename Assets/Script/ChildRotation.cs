using UnityEngine;

public class ChildRotation : MonoBehaviour
{
    public Transform fpsCamera;

    // Initial Z-axis rotation offset
    private float initialZRotationOffset;

    void Start()
    {
        // Check if the FPS camera is assigned
        if (fpsCamera != null)
        {
            // Calculate the initial Z-axis rotation offset based on the current Z-axis rotation of the child
            initialZRotationOffset = transform.rotation.eulerAngles.z;
        }
        else
        {
            Debug.LogError("FPS Camera is not assigned!");
        }
    }

    void Update()
    {
        // Check if the FPS camera is assigned
        if (fpsCamera != null)
        {
            // Get the X-axis rotation of the FPS camera
            float cameraRotationX = fpsCamera.rotation.eulerAngles.x;

            // Update the Z-axis rotation of the child based on the initial offset and the FPS camera's X-axis rotation
            float newZRotation = initialZRotationOffset + cameraRotationX;

            // Set the new rotation for the child
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newZRotation);
        }
    }
}
