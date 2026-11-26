using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [Header("Swing Settings")]
    public float swingAngle = 60f;
    public float swingSpeed = 1.5f;
    public Transform pivot;
    private Quaternion startRotation;
    void Start()
    {
        if (pivot == null)
            pivot = transform.parent;
        startRotation = transform.localRotation;
    }
    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.localRotation = startRotation * Quaternion.Euler(0, 0, angle);
    }
}