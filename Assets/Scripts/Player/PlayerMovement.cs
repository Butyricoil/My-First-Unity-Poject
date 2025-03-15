using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float strafeSpeed = 10f;
    [SerializeField] private float jumpForce = 30f;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;

    private bool shouldJump = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.Jump && IsGrounded())
        {
            shouldJump = true;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
        if (shouldJump)
        {
            PerformJump();
            shouldJump = false;
        }
    }

    private void MovePlayer()
    {
        float horizontal = playerInput.HorizontalInput;
        Vector3 moveDirection = Vector3.forward * runSpeed + Vector3.right * horizontal * strafeSpeed;

        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);
    }

    private void PerformJump()
    {
        transform.DORewind();
        transform.DOShakeScale(0.5f, 0.5f, 3, 30);
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}