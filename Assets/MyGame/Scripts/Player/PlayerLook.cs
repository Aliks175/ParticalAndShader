using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    // ������ ��� ����������� 
    [SerializeField] private GameObject _head;
    // ��� ��� �������� = 0 ���������� ����� 
    private float xRotation = 0;
    // ��������������� �� ���� 
    [SerializeField] private float ySensitivity = 30f;
    [SerializeField] private float xSensitivity = 30f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // ����� ��������� �, � �� �������� ����/���� � ������/����� �
    public void ProcessLook(Vector2 vector2)
    {
        float mouseX = vector2.x;
        float mouseY = vector2.y;

        // �������� �� ������ ���� �������� �������� �����/���� ��������� �� ����� ����� �������� Update (Time.deltaTime)
        // � ��������� �� ���� ����������������
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;


        // ������������ �������  ���� � ��� 
        xRotation = Mathf.Clamp(xRotation, -70, 70);

        // ������� ������ ���� � ��� �� ��������� ��� � ��� ���� ��� � �� �������� 
        _head.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //������������ ������ �� ��� Y �� ��� �������� �� � �� ��������
        //��������� �� ����� ����� �������� Update (Time.deltaTime)
        // � ��������� �� ���� ����������������
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}