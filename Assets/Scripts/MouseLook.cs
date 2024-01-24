using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1000f; // Mouse sensitivity.

    void Update()
    {
        // Get mouse input.
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Rotate the player based on mouse input.
        transform.Rotate(Vector3.up * mouseX);
    }
}

