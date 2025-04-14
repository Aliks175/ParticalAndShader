using UnityEngine;

public abstract class Interacteble : MonoBehaviour
{
    public bool UseEvents;// ��� ������ ��� �������� ����� �� �� ��������� ������ � ��������� 
    public string Prompt;// ��� ����� ��������� ������ ��������� ����� 

    public void BaseInteract()// ���������� �������������� 
    {
        if (UseEvents)// ���� ������������� ������� ������� �� �� �� ��������
        {
            GetComponent<InteractebleEvents>().OnInteract?.Invoke();
        }
        Interact();
    }

    protected virtual void Interact()// �������������� �������������� ��� ������� �������� 
    {

    }
}
