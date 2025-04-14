using UnityEngine;

public class InputManager : MonoBehaviour
{
    // ��� �# ����� �������� ������ � ���� ��� ���� ����� �������� 
    private PlayerSystemActions _playerInput;

    // ����� �� �������� ���� ����� �������� ����������� ������ 
    public PlayerSystemActions.PlayerActions _playerActions;

    //// ��������� ����� ����������� �����������
    private PlayerMover _playerMover;

    //// ��������� ����� ����������� �������� ������� � ��������� ������ 
    private PlayerLook _playerLook;


    private PlayerAttack _playerAttack;


    private void Awake()
    {
        _playerInput = new PlayerSystemActions();
        _playerActions = _playerInput.Player;
        _playerMover = GetComponent<PlayerMover>();
        _playerLook = GetComponent<PlayerLook>();
        _playerAttack = GetComponent<PlayerAttack>();

        //// �� ��������� ������ => ��������� Context �� �������� �� ������� �� ���� ������ �� ������
        //// �� ��� ���� �������� ������ ��� ����� �� PlayerMover
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
        // ���� ����������� 
        _playerMover.ProcessMove(_playerActions.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        // ���� �������� 
        _playerLook.ProcessLook(_playerActions.Look.ReadValue<Vector2>());
    }
}