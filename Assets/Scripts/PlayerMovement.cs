using Unity.VisualScripting;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 7.5f;
    public float moveSpeed = 3f;
    public float minHeight = -1f; 
    public float maxHeight = 1f;
    public float maxRight = 8f;

    public float maxLeft = 2f;

    void Start()
    {
        string diff = PlayerPrefs.GetString("Difficulty", "Medium");

        switch (diff)
        {
            case "Easy":
                forwardSpeed = 5f;
                moveSpeed = 2.5f;
                break;
            case "Medium":
                forwardSpeed = 7.5f;
                moveSpeed = 3f;
                break;
            case "Hard":
                forwardSpeed = 12f;
                moveSpeed = 5f;
                break;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float vertical = Input.GetAxisRaw("Vertical");     

        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
        pos.x = Mathf.Clamp(pos.x, maxLeft, maxRight);
        transform.position = pos;
    }
}
