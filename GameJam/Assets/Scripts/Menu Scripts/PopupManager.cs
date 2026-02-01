using TMPro;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    public float displayTime = 4f;

    public void ShowPopup(string message)
    {
        popupText.text = message;
        Invoke("HidePopup", displayTime);
    }

    void HidePopup()
    {
        popupText.text = "";
    }
}
