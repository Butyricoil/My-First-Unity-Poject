using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public bool IsJumpTriggered { get; private set; }
    public bool IsMoving { get; private set; } // Новый флаг для отслеживания движения

    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();

        _playerInputActions.Player.Jump.performed += OnJump;
        _playerInputActions.Player.Movement.performed += OnMovement;
        _playerInputActions.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        IsJumpTriggered = context.performed;
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        IsMoving = true; // Устанавливаем флаг движения
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        MovementInput = Vector2.zero;
        IsMoving = false; // Сбрасываем флаг движения
    }

    public void ResetJumpTrigger()
    {
        IsJumpTriggered = false;
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Jump.performed -= OnJump;
        _playerInputActions.Player.Movement.performed -= OnMovement;
        _playerInputActions.Player.Movement.canceled -= OnMovementCanceled;
        _playerInputActions.Player.Disable();
    }
}