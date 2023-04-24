using Scripts.Gameloop;
using UnityEngine;

public class btn_closeActivePopup : MonoBehaviour
{
    public void CloseActivePopup()
    {
        PopupSystem.Instance.CloseActivePopup();
    }
}
