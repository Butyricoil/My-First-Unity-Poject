using System;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float runSpeed = 10f;

    [SerializeField]
    private float strafeSpeed = 10f;

    [SerializeField]
    private float jumpForce = 30f;

    private bool strafeLeft = false;
    private bool strafeRight = false;
    private bool doJump = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            gm.EndGame();
            Debug.Log("End Game");
        }

        if (collision.collider.CompareTag("Finish"))
        {
            Debug.Log("You Win!");
        }
    }

    void Update()
    {
        strafeLeft = Input.GetKey(KeyCode.D);
        strafeRight = Input.GetKey(KeyCode.A);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;
        }

        if (transform.position.y < -5f)
        {
            Debug.Log("End Game");
            gm.EndGame();
        }
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.forward * runSpeed;

        if (strafeLeft)
        {
            moveDirection += Vector3.right * strafeSpeed;
        }
        else if (strafeRight)
        {
            moveDirection += Vector3.left * strafeSpeed;
        }

        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);

        if (doJump && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            transform.DORewind();
            transform.DOShakeScale(.5f, .5f, 3, 30);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            doJump = false;
        }
    }
}
