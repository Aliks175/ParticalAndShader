using UnityEngine;

[RequireComponent(typeof(PlayerUi))]
public class PlayerInteracteble : MonoBehaviour
{
    [SerializeField] private Camera _camera;// то относительно чего мы пускаем луч
    [SerializeField] private float _distance;// дистанчия нашего взаимодействия 
    [SerializeField] private LayerMask _mask;// тот физический слой с которым мы взаимодействуем

    private PlayerUi playerUi;// отвечает за отображение текста на экране 
    private InputManager inputManager;

    private void Start()
    {
        playerUi = GetComponent<PlayerUi>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUi.UpdateText(string.Empty);// опустошаем строку если в поле зрения нет объектов для взаимодействия 


        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);// запускаем луч из камеры в прямом направлении 

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _distance, _mask))// запуск рэйкаста
        {
            if (hit.collider.gameObject.TryGetComponent(out Interacteble interacteble))//проверяем есть ли объект для взаимодействия
            {
                playerUi.UpdateText(interacteble.Prompt); // обновляем наш текст подсказку 
                if (inputManager._playerActions.Interact.WasPressedThisFrame())//сработает в тот самый кадр когда мы нашмем на кнопу взаимодействия
                {
                    interacteble.BaseInteract();// выполнит взаимодействие с объектом 
                }
            }
        }

    }
}
