using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target; // Объект, вокруг которого будет вращаться камера
    public float rotationSpeed = 5f; // Скорость вращения
    public float distanceFromTarget = 5f; // Расстояние от объекта

    private float mouseX; // Положение мыши по оси X
    private Vector3 previousMousePosition; // Предыдущая позиция мыши

    void Update()
    {
        // Проверяем свайп по экрану
        if (Input.touchCount > 0)
        {
            // Обрабатываем каждое касание
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    // Получаем смещение свайпа по оси X
                    float swipeDeltaX = touch.deltaPosition.x;

                    // Применяем смещение к положению мыши
                    mouseX += swipeDeltaX * rotationSpeed;
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            // Получаем смещение мыши по оси X
            float swipeDeltaX = Input.mousePosition.x - previousMousePosition.x;

            // Применяем смещение к положению мыши
            mouseX += swipeDeltaX * rotationSpeed;
        }

        // Обновляем предыдущую позицию мыши
        previousMousePosition = Input.mousePosition;

        // Применяем вращение камеры вокруг объекта
        Quaternion rotation = Quaternion.Euler(0f, mouseX, 0f);
        transform.position = target.position - (rotation * Vector3.forward) * distanceFromTarget;

        // Направляем камеру на объект
        transform.LookAt(target);
    }
}