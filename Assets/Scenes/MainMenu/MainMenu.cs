using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StoryMode()
    {
        SceneManager.LoadScene("LevelChoose");
    }

    public void MultiplayerOnlineMode()
    {
        SceneManager.LoadScene("Launcher");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void WhatsNew()
    {
        SceneManager.LoadScene("WhatsNew");
    }
}
