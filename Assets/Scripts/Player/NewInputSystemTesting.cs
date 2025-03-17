using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemTesting : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions;
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Movement.performed += Movement_performed;
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump" + context.phase);
            _rigidbody.AddForce(Vector3.up *5f, ForceMode.Impulse);
        }
    }

}
