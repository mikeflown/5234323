using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float turnSpeed = 120f;
    public float jumpForce = 8f;
    private CharacterController controller;
    private Rigidbody rb;
    private Vector3 velocity;
    private bool isGrounded;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    void Update()
    {
        if (controller == null || !controller.enabled) return;
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0) velocity.y = -2f;
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        float move = 0f;
        float turn = 0f;
        if (keyboard.wKey.isPressed) move += 1f;
        if (keyboard.sKey.isPressed) move -= 1f;
        if (keyboard.aKey.isPressed) turn -= 1f;
        if (keyboard.dKey.isPressed) turn += 1f;
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        Vector3 moveDir = transform.forward * move * moveSpeed;
        controller.Move(moveDir * Time.deltaTime);
        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}