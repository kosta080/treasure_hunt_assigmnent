using UnityEngine;
using Scripts.Gameloop;

public class UiButton : MonoBehaviour
{
    public void OpenHintPopup()
    {
        PopupSystem.Instance.ShowRoundPopup();
    }
}
