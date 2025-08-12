using Unity.VisualScripting;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 4f;
    public float moveSpeed = 3f;
    public float minHeight = -3f; 
    public float maxHeight = 3f;
    public float maxRight = 8f;
    public float maxLeft = 2f;

    void Update()
    {
        // Constant forward movement along world Z axis
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        // Player input
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down

        // Apply movement (world space)
        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Clamp height
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
        pos.x = Mathf.Clamp(pos.x, maxLeft, maxRight);
        transform.position = pos;
    }
}
