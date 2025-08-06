using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 5f;
    public float laneChangeSpeed = 10f;
    public float jumpForce = 20f;
    public float diveForce = 20f;
    public float gravity = 30f;

    [Header("Lane Settings")]
    public float laneDistance = 3f; 
    private int currentLane = 1;
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

        float currentX = transform.position.x;
        if (Mathf.Abs(currentX - targetX) > 0.05f)
        {
            float direction = Mathf.Sign(targetX - currentX);
            moveDirection.x = direction * laneChangeSpeed;
            isChangingLanes = true;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.x = targetX;
            transform.position = pos;
            moveDirection.x = 0;
            isChangingLanes = false;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(FlyDownAndUp());
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    void SetTargetLane()
    {
        targetX = (currentLane - 1) * laneDistance;
    }

    IEnumerator FlyDownAndUp()
    {
        float duration = 0.3f;
        float flyHeight = 2f;
        float targetY = 0f;

        Vector3 startPos = transform.position;
        Vector3 downPos = new Vector3(startPos.x, targetY, startPos.z);

        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, downPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = downPos;

        yield return new WaitForSeconds(0.2f);

        elapsed = 0f;
        Vector3 upPos = new Vector3(startPos.x, flyHeight, startPos.z);
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(downPos, upPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = upPos;
    }
}
