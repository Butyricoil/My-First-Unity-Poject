using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    private Rigidbody _rigidbody;
    private PlayerInputHandler _inputHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector2 inputVector = _inputHandler.MovementInput;
        _rigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * _speed, ForceMode.Force);
    }

    private void Jump()
    {
        if (_inputHandler.JumpTriggered)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _inputHandler.ResetJumpTrigger(); // Сбрасываем триггер после прыжка
        }
    }
}