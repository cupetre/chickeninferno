using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 5f;
    public float laneChangeSpeed = 10f;
    public float jumpForce = 20f;
    public float gravity = 30f;

    [Header("Lane Settings")]
    public float laneDistance = 3f; // Distance between lanes
    private int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    private bool isChangingLanes = false;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float targetX;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("Character Controller is not found on the GameObject");
            enabled = false;
        }
    }

    void Update()
    {
        moveDirection.z = forwardSpeed;

        if (controller.isGrounded)
        {
            moveDirection.y = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Handle lane switching input
        if (!isChangingLanes)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentLane > 0)
                {
                    currentLane--;
                    SetTargetLane();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentLane < 2)
                {
                    currentLane++;
                    SetTargetLane();
                }
            }
        }

        // Move toward target lane on X axis
        float currentX = transform.position.x;
        if (Mathf.Abs(currentX - targetX) > 0.05f)
        {
            float direction = Mathf.Sign(targetX - currentX);
            moveDirection.x = direction * laneChangeSpeed;
            isChangingLanes = true;
        }
        else
        {
            // Snap to lane when close enough
            Vector3 pos = transform.position;
            pos.x = targetX;
            transform.position = pos;
            moveDirection.x = 0;
            isChangingLanes = false;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    void SetTargetLane()
    {
        targetX = (currentLane - 1) * laneDistance;
    }
}