using UnityEngine;

public abstract class Interacteble : MonoBehaviour
{
    public bool UseEvents;// это тригер для проверки будем ли мы добавлять ивенты в редакторе 
    public string Prompt;// это текст подсказки которы считывает игрок 

    public void BaseInteract()// активирует взаимодействие 
    {
        if (UseEvents)// если использование ивентов активно то мы их вызываем
        {
            GetComponent<InteractebleEvents>().OnInteract?.Invoke();
        }
        Interact();
    }

    protected virtual void Interact()// индивидуальное взаимодействие для каждого предмета 
    {

    }
}
