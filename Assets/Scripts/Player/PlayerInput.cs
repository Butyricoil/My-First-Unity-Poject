using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    public bool Jump { get; private set; }

    private Vector2 touchStartPos; // Начальная позиция касания
    private float swipeThreshold = 50f; // Минимальная дистанция для свайпа
    private bool isSwiping = false; // Флаг, указывающий, что идет свайп

    void FixedUpdate()
    {
        // Сбрасываем значения каждый кадр
        HorizontalInput = 0f;
        Jump = false;

        // Обрабатываем касания
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Берем первое касание

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position; // Запоминаем начальную позицию
                    isSwiping = false; // Сбрасываем флаг свайпа
                    break;

                case TouchPhase.Moved:
                    // Проверяем, начался ли свайп
                    if (!isSwiping && Vector2.Distance(touch.position, touchStartPos) > swipeThreshold)
                    {
                        isSwiping = true; // Начался свайп
                    }

                    // Если свайп начался, определяем направление
                    if (isSwiping)
                    {
                        Vector2 swipeDelta = touch.position - touchStartPos;
                        HorizontalInput = Mathf.Clamp(swipeDelta.x / Screen.width * 2f, -1f, 1f); // Нормализуем значение
                    }
                    break;

                case TouchPhase.Stationary:
                    // Если палец стоит на месте, продолжаем движение в текущем направлении
                    if (isSwiping)
                    {
                        Vector2 swipeDelta = touch.position - touchStartPos;
                        HorizontalInput = Mathf.Clamp(swipeDelta.x / Screen.width * 2f, -1f, 1f);
                    }
                    break;

                case TouchPhase.Ended:
                    // Если это было короткое касание, прыжок
                    if (!isSwiping && Vector2.Distance(touch.position, touchStartPos) < swipeThreshold)
                    {
                        Jump = true; // Прыжок
                    }
                    isSwiping = false; // Сбрасываем флаг свайпа
                    break;
            }
        }
    }
}