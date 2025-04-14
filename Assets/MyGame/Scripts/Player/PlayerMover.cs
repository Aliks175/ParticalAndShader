using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //наши параметры скорость персонажа , высота прыжка 
    [Header("Player-Parameters")]
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float jumpHeight = 3.0f;

    // реализаци€ гравитации 
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
        // каждый Update мы актуально провер€ем стоим ли мы на земле 
        _isGrounded = _controller.isGrounded;
    }


    // здесь заключены все движени€ игрока 
    public void ProcessMove(Vector2 pos)
    {
        // мы принемаем значение из ’ и ” так как мы не движимс€ по оси вверх вниз
        // мы используем ’ как влево вправо
        // мы используем ” как вперед назад поэтому приравниваем в ось Z 
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = pos.x;
        moveDirection.z = pos.y;

        // TransformDirection - перводит из локальных координат в глобальные нашего игрока
        //мы домножаем на скорость игрока
        //домножаем на врем€ между вызовами Update (Time.deltaTime)
        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);

        // работа гравитации
        _playerVelocity.y += _gravity * Time.deltaTime;

        //проверка стоит ли персонаж на земле если да то скорость направленной на землю ограничена -2
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2;
        }

        // применение сил гравитации
        _controller.Move(_playerVelocity * Time.deltaTime);

    }

    // прыжок 
    public void Jump()
    {
        // проверка на землю 
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * _gravity);
        }
    }

}

