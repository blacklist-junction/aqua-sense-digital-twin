using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Transform target;         // Object to rotate around
    public float rotationSpeed = 5f; // Sensitivity of rotation

    private Vector3 offset;

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraRotator: No target assigned!");
            return;
        }

        // Save initial offset
        offset = transform.position - target.position;
    }

    void Update()
    {
        if (target == null) return;

        if (Input.GetMouseButton(0))
        {
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;

            // Rotate around target horizontally
            transform.RotateAround(target.position, Vector3.up, horizontal);

            // Rotate around target vertically (camera's right axis)
            transform.RotateAround(target.position, transform.right, vertical);
        }
    }
}
