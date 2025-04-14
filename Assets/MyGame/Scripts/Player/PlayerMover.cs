using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //���� ��������� �������� ��������� , ������ ������ 
    [Header("Player-Parameters")]
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float jumpHeight = 3.0f;

    // ���������� ���������� 
    [Header("Physic")]
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private bool _isGrounded;

    private CharacterController _controller;
    private Vector3 _playerVelocity;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // ������ Update �� ��������� ��������� ����� �� �� �� ����� 
        _isGrounded = _controller.isGrounded;
    }


    // ����� ��������� ��� �������� ������ 
    public void ProcessMove(Vector2 pos)
    {
        // �� ��������� �������� �� � � � ��� ��� �� �� �������� �� ��� ����� ����
        // �� ���������� � ��� ����� ������
        // �� ���������� � ��� ������ ����� ������� ������������ � ��� Z 
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = pos.x;
        moveDirection.z = pos.y;

        // TransformDirection - �������� �� ��������� ��������� � ���������� ������ ������
        //�� ��������� �� �������� ������
        //��������� �� ����� ����� �������� Update (Time.deltaTime)
        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);

        // ������ ����������
        _playerVelocity.y += _gravity * Time.deltaTime;

        //�������� ����� �� �������� �� ����� ���� �� �� �������� ������������ �� ����� ���������� -2
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2;
        }

        // ���������� ��� ����������
        _controller.Move(_playerVelocity * Time.deltaTime);

    }

    // ������ 
    public void Jump()
    {
        // �������� �� ����� 
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * _gravity);
        }
    }

}

