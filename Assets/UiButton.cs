using UnityEngine;
using Scripts.Gameloop;
using UnityEngine.SceneManagement;

public class UiButton : MonoBehaviour
{
    public void OpenHintPopup()
    {
        PopupSystem.Instance.ShowPopup("Round");
    }
    public void Continue()
    {
        PopupSystem.Instance.CloseActivePopup();
    }
    public void OpenGameMenu()
    {
        PopupSystem.Instance.ShowPopup("GameMenu");
    }  
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void GoToLevel()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
