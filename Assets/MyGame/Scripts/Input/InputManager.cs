using UnityEngine;

public class InputManager : MonoBehaviour
{
    // наш С# класс действий хранит в себе все наши карты действий 
    private PlayerSystemActions _playerInput;

    // здесь мы кэшируем нашу карту действий перемещения игрока 
    public PlayerSystemActions.PlayerActions _playerActions;

    //// отдельный класс реализующий перемещение
    private PlayerMover _playerMover;

    //// отдельный класс реализующий вращение камерой и развороты игрока 
    private PlayerLook _playerLook;


    private PlayerAttack _playerAttack;


    private void Awake()
    {
        _playerInput = new PlayerSystemActions();
        _playerActions = _playerInput.Player;
        _playerMover = GetComponent<PlayerMover>();
        _playerLook = GetComponent<PlayerLook>();
        _playerAttack = GetComponent<PlayerAttack>();

        //// Мы используя лямбду => принимаем Context из подписки на событие мы сним ничего не делаем
        //// но при этом вызываем нужный нам метод из PlayerMover
        _playerActions.Jump.performed += Context => _playerMover.Jump();

        _playerActions.Attack.performed += Context => _playerAttack.Attack();
    }

    private void OnEnable()
    {
        _playerActions.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // наше перемещение 
        _playerMover.ProcessMove(_playerActions.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        // наше вращение 
        _playerLook.ProcessLook(_playerActions.Look.ReadValue<Vector2>());
    }
}