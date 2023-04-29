using Scripts.Helpers.cam;
using Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gui
{
    public class SettingsUi : MonoBehaviour
    {
        [SerializeField]
        private Toggle keyboard;
        [SerializeField]
        private Toggle mouse;
        [SerializeField]
        private Toggle gui;

        [SerializeField]
        private Toggle topDown;
        [SerializeField]
        private Toggle firstPerson;


        private PlayerMovement playerMovement;
        private CamBehaviour camBehaviour;

        const string MOUSE_TITLE = "Mouse";
        const string TOUCH_TITLE = "Touch";

        // Start is called before the first frame update
        void Start()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            camBehaviour = FindObjectOfType<CamBehaviour>();

            if (playerMovement)
            {
                setInputToggleState();
                setMouseTouchText();

                keyboard.onValueChanged.AddListener(keyboardValChange);
                mouse.onValueChanged.AddListener(mouseValChange);
                gui.onValueChanged.AddListener(guiValChange);
            }
            else
            {
                Debug.Log("player script was not found, you can not change input method");
            }

            if (camBehaviour)
            {
                setPovToggleState();

                topDown.onValueChanged.AddListener(tpValChange);
                firstPerson.onValueChanged.AddListener(fpValChange);
            }
            else
            {
                Debug.Log("camera script was not found, you can not change point of view");
            }

        }
        private void setInputToggleState()
        {
            keyboard.isOn = playerMovement.InputMethod == PlayerMovement.InputMethods.keyboard;
            mouse.isOn = playerMovement.InputMethod == PlayerMovement.InputMethods.mouse;
            gui.isOn = playerMovement.InputMethod == PlayerMovement.InputMethods.gui;
        }
        private void setPovToggleState()
        {
            topDown.isOn = camBehaviour.CamState == CamBehaviour.CamStates.topDown;
            firstPerson.isOn = camBehaviour.CamState == CamBehaviour.CamStates.firstPerson;
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
        private void fpValChange(bool val)
        {
            if (!val)
                return;
            camBehaviour.CamState = CamBehaviour.CamStates.firstPerson;
            playerMovement.InputMethod = PlayerMovement.InputMethods.gui;
            setPovToggleState();
            setInputToggleState();
        }
        private void tpValChange(bool val)
        {
            if (!val)
                return;
            camBehaviour.CamState = CamBehaviour.CamStates.topDown;
            playerMovement.InputMethod = PlayerMovement.InputMethods.mouse;
            setPovToggleState();
            setInputToggleState();
        }

    }
}