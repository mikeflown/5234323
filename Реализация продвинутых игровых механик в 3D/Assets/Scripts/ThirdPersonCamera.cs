using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    [Header("Offset")]
    public Vector3 offset = new Vector3(0, 3f, -5f);
    public float smoothSpeed = 8f;
    [Header("Look")]
    public float lookHeight = 1.5f;
    [Header("State")]
    public bool followRotation = true;
    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPosition;
        if (followRotation)
        {
            desiredPosition = target.position + target.TransformDirection(offset);
        }
        else
        {
            desiredPosition = target.position + offset;
        }
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        Vector3 lookPoint = target.position + Vector3.up * lookHeight;
        transform.LookAt(lookPoint);
    }
    public void DisableRotationFollow()
    {
        followRotation = false;
    }
}