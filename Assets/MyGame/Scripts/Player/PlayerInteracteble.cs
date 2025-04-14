using UnityEngine;

[RequireComponent(typeof(PlayerUi))]
public class PlayerInteracteble : MonoBehaviour
{
    [SerializeField] private Camera _camera;// �� ������������ ���� �� ������� ���
    [SerializeField] private float _distance;// ��������� ������ �������������� 
    [SerializeField] private LayerMask _mask;// ��� ���������� ���� � ������� �� ���������������

    private PlayerUi playerUi;// �������� �� ����������� ������ �� ������ 
    private InputManager inputManager;

    private void Start()
    {
        playerUi = GetComponent<PlayerUi>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUi.UpdateText(string.Empty);// ���������� ������ ���� � ���� ������ ��� �������� ��� �������������� 


        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);// ��������� ��� �� ������ � ������ ����������� 

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _distance, _mask))// ������ ��������
        {
            if (hit.collider.gameObject.TryGetComponent(out Interacteble interacteble))//��������� ���� �� ������ ��� ��������������
            {
                playerUi.UpdateText(interacteble.Prompt); // ��������� ��� ����� ��������� 
                if (inputManager._playerActions.Interact.WasPressedThisFrame())//��������� � ��� ����� ���� ����� �� ������ �� ����� ��������������
                {
                    interacteble.BaseInteract();// �������� �������������� � �������� 
                }
            }
        }

    }
}
