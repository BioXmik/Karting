using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target; // ������, ������ �������� ����� ��������� ������
    public float rotationSpeed = 5f; // �������� ��������
    public float distanceFromTarget = 5f; // ���������� �� �������

    private float mouseX; // ��������� ���� �� ��� X
    private Vector3 previousMousePosition; // ���������� ������� ����

    void Update()
    {
        // ��������� ����� �� ������
        if (Input.touchCount > 0)
        {
            // ������������ ������ �������
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    // �������� �������� ������ �� ��� X
                    float swipeDeltaX = touch.deltaPosition.x;

                    // ��������� �������� � ��������� ����
                    mouseX += swipeDeltaX * rotationSpeed;
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            // �������� �������� ���� �� ��� X
            float swipeDeltaX = Input.mousePosition.x - previousMousePosition.x;

            // ��������� �������� � ��������� ����
            mouseX += swipeDeltaX * rotationSpeed;
        }

        // ��������� ���������� ������� ����
        previousMousePosition = Input.mousePosition;

        // ��������� �������� ������ ������ �������
        Quaternion rotation = Quaternion.Euler(0f, mouseX, 0f);
        transform.position = target.position - (rotation * Vector3.forward) * distanceFromTarget;

        // ���������� ������ �� ������
        transform.LookAt(target);
    }
}