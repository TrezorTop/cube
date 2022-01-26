using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    public Transform playerRef;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.position = playerRef.position + offset;
    }
}