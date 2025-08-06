using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow;

    public Vector3 fixed_dist;

    // gets initiated after Update is activated
    void LateUpdate()
    {
        if (targetToFollow != null)
        {
            // constant that the camera will follow
            transform.position = targetToFollow.position + fixed_dist;
        }
    } 
}