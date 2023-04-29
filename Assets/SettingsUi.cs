using Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUi : MonoBehaviour
{
    [SerializeField]
    private Toggle keyboard;
    [SerializeField]
    private Toggle mouse;
    [SerializeField]
    private Toggle gui;

    private PlayerMovement playerMovement;

    const string MOUSE_TITLE = "Mouse";
    const string TOUCH_TITLE = "Touch";

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (!playerMovement)
        {
            Debug.Log("player script was not found, you can not change input method");
            return;
        }

        setInputToggleState();
        setMouseTouchText();

        keyboard.onValueChanged.AddListener(keyboardValChange);
        mouse.onValueChanged.AddListener(mouseValChange);
        gui.onValueChanged.AddListener(guiValChange);

    }
    private void setInputToggleState()
    {
        keyboard.isOn = playerMovement.InputMethod == PlayerMovement.InputMethods.keyboard;
        mouse.isOn = playerMovement.InputMethod == PlayerMovement.InputMethods.mouse;
        gui.isOn = playerMovement.InputMethod == PlayerMovement.InputMethods.gui;
    }
    private void setMouseTouchText()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            mouse.transform.gameObject.GetComponentInChildren<Text>().text = MOUSE_TITLE;
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            mouse.transform.gameObject.GetComponentInChildren<Text>().text = MOUSE_TITLE;
        }
        else
        {
            mouse.transform.gameObject.GetComponentInChildren<Text>().text = TOUCH_TITLE;
        }
    }

    private void keyboardValChange(bool val)
    {
        if (!val) 
            return;
        playerMovement.InputMethod = PlayerMovement.InputMethods.keyboard;
        setInputToggleState();
    }
    private void mouseValChange(bool val)
    {
        if (!val) 
            return;
        playerMovement.InputMethod = PlayerMovement.InputMethods.mouse;
        setInputToggleState();
    }
    private void guiValChange(bool val) 
    {
        if (!val) 
            return;
        playerMovement.InputMethod = PlayerMovement.InputMethods.gui;
        setInputToggleState();
    }

}
