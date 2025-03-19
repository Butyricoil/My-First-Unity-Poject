using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public bool JumpTriggered { get; private set; }

    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();

        _playerInputActions.Player.Jump.performed += OnJump;
        _playerInputActions.Player.Movement.performed += OnMovement;
        _playerInputActions.Player.Movement.canceled += OnMovement;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        JumpTriggered = context.performed;
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    public void ResetJumpTrigger()
    {
        JumpTriggered = false;
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Jump.performed -= OnJump;
        _playerInputActions.Player.Movement.performed -= OnMovement;
        _playerInputActions.Player.Movement.canceled -= OnMovement;
        _playerInputActions.Player.Disable();
    }
}