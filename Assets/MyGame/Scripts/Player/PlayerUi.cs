using TMPro;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;

    public void UpdateText(string text)
    {
        promptText.text = text;
    }
}
