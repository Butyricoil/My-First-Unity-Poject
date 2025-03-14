using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    public bool Jump { get; private set; }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        Jump = Input.GetKeyDown(KeyCode.Space); //replaace for android
    }
}