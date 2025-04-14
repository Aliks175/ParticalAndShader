using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    // камера наш наблюдатель 
    [SerializeField] private GameObject _head;
    // наш угл поворота = 0 паралельно земле 
    private float xRotation = 0;
    // чуствительность по осям 
    [SerializeField] private float ySensitivity = 30f;
    [SerializeField] private float xSensitivity = 30f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // метод принимает Х, У по монетору верх/вниз У вправо/влево Х
    public void ProcessLook(Vector2 vector2)
    {
        float mouseX = vector2.x;
        float mouseY = vector2.y;

        // Отнимаем от нашего угла поворота движение вверх/вниз домножаем на время между вызовами Update (Time.deltaTime)
        // и домножаем на нашу чувствительность
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;


        // ограничиваем значние  Макс и Мин 
        xRotation = Mathf.Clamp(xRotation, -70, 70);

        // вращаем камеру верх в низ по локальной оси Х это таже ось У по монитору 
        _head.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //поворачиваем игрока по оси Y На его движение по Х на мониторе
        //домножаем на время между вызовами Update (Time.deltaTime)
        // и домножаем на нашу чувствительность
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}