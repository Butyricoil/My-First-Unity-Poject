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

        if (Input.GetKeyDown("Space"))
        {
            doJump = true;
        }
        else
        {
            doJump = false;
        }
    }

    void FixedUpdate()
        {
            rb.AddForce(0, 0, runSpeed * Time.deltaTime);
        }

}