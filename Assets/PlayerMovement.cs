using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float runSpeed = 500f;
    public float strafeSpeed = 500f;
    public float jumpForce = 30f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;

    void Update()
    {
        if (Input.GetKey("d"))
        {
            strafeLeft = true;
        }
        else
        {
            strafeLeft = false;
        }

        if (Input.GetKey("a"))
        {
            strafeRight = true;
        }
        else
        {
            strafeRight = false;
        }

        if (Input.GetKeyDown("space"))
        {
            doJump = true;
        }

        if (transform.position.y < -5f)
        {
            Debug.Log("End of The Game")
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, runSpeed * Time.deltaTime);

        if (strafeLeft)
        {
            rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (strafeRight)
        {
            rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (doJump && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            doJump = false;
        }
    }
}