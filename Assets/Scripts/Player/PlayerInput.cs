using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool StrafeLeft { get; private set; }
    public bool StrafeRight { get; private set; }
    public bool Jump { get; private set; }

    void Update()
    {
        StrafeLeft = Input.GetKey(KeyCode.D);
        StrafeRight = Input.GetKey(KeyCode.A);
        Jump = Input.GetKeyDown(KeyCode.Space);
    }
}