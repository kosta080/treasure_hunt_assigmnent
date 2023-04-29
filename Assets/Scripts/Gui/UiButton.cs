using UnityEngine;
using Scripts.Gameloop;
using UnityEngine.SceneManagement;
using Scripts.Infra;

namespace Scripts.Gui
{
    public class UiButton : MonoBehaviour
    {
        public void OpenHintPopup()
        {
            if (SoundManager.Instance)
                SoundManager.Instance.playUiClick();
            PopupSystem.Instance.ShowPopup("Round");
        }
        public void Continue()
        {
            if (SoundManager.Instance)
                SoundManager.Instance.playUiClick();
            PopupSystem.Instance.CloseActivePopup();
        }
        public void OpenGameMenu()
        {
            Debug.Log("OpenGameMenu");
            if (SoundManager.Instance)
                SoundManager.Instance.playUiClick();
            PopupSystem.Instance.ShowPopup("GameMenu");
        }
        public void GoToMainMenu()
        {
            if (SoundManager.Instance)
                SoundManager.Instance.playUiClick();
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        public void GoToLevel()
        {
            if (SoundManager.Instance)
                SoundManager.Instance.playUiClick();
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }

        public void ExitGame()
        {
            if (SoundManager.Instance)
                SoundManager.Instance.playUiClick();
            Application.Quit();
        }
    }
}