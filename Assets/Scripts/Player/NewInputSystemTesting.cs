using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemTesting : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerInputActions _playerInputActions; // Сохраняем экземпляр Input Actions

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // Инициализация системы ввода
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();

        // Подписка на события
        _playerInputActions.Player.Jump.performed += Jump;
        _playerInputActions.Player.Movement.performed += Movement_performed;
    }

    private void Update()
    {
        Vector2 inputVector =  _playerInputActions.Player.Movement.ReadValue<Vector2>();
        float _speed = 5f;
        _rigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * _speed, ForceMode.Force);
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        // Здесь можно добавить логику для движения
        Vector2 inputVector = context.ReadValue<Vector2>();
        float _speed = 5f;
        _rigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * _speed, ForceMode.Force);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump" + context.phase);
            _rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    private void OnDestroy()
    {
        // Отписываемся от событий и отключаем систему ввода
        if (_playerInputActions != null)
        {
            _playerInputActions.Player.Jump.performed -= Jump;
            _playerInputActions.Player.Movement.performed -= Movement_performed;
            _playerInputActions.Player.Disable();
        }
    }
}