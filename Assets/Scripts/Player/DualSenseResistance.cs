// using UnityEngine;
// using UnityEngine.InputSystem;
//
// public class DualSenseResistance : MonoBehaviour
// {
//     private PlayerInput playerInput;
//     private Gamepad gamepad;
//     private Vector2 leftStickValue;
//
//     [SerializeField] private float resistanceFactor = 0.5f; // Настройка фактора сопротивления
//
//     private void Start()
//     {
//         playerInput = GetComponent<PlayerInput>(); // Получаем компонент PlayerInput
//         playerInput.onControlsChanged += OnControlsChanged; // Подписываемся на событие изменения контролов
//     }
//
//     private void OnControlsChanged(PlayerInput input)
//     {
//         gamepad = (Gamepad)input.GetDevice("Gamepad"); // Получаем геймпад из устройств ввода
//     }
//
//     private void Update()
//     {
//         if (gamepad == null)
//             return;
//
//         leftStickValue = gamepad.leftStick.ReadValue(); // Считываем значение левого стика
//
//         // Применяем сопротивление
//         ApplyResistance();
//     }
//
//     private void ApplyResistance()
//     {
//         // Модифицируем значение левого стика
//         leftStickValue *= (1f - resistanceFactor);
//
//         // Применяем модифицированное значение обратно
//         gamepad.leftStick = leftStickValue;
//     }
// }