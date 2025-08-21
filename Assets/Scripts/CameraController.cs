using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 fixed_dist;

    void LateUpdate()
    {
        if (targetToFollow != null)
        {
            Vector3 currentPos = transform.position;

            currentPos.z = targetToFollow.position.z + fixed_dist.z;

            transform.position = currentPos;
        }
    }
}
