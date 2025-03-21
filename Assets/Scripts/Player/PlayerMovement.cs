using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    private Rigidbody _rigidbody;
    private PlayerInputHandler _inputHandler;
    private bool _isGrounded;

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
        if (_inputHandler.IsMoving) // Проверяем, активен ли ввод
        {
            Vector2 inputVector = _inputHandler.MovementInput;
            Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y) * _speed;
            _rigidbody.linearVelocity = new Vector3(movement.x, _rigidbody.linearVelocity.y, movement.z);
        }
        else
        {
            _rigidbody.linearVelocity = new Vector3(0, _rigidbody.linearVelocity.y, 0); // Останавливаем движение
        }
    }

    private void Jump()
    {
        if (_inputHandler.IsJumpTriggered && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _inputHandler.ResetJumpTrigger(); // Сбрасываем триггер после прыжка
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, что игрок столкнулся с объектом, у которого есть коллайдер
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Проверяем, что игрок больше не контактирует с объектом
        _isGrounded = false;
    }
}