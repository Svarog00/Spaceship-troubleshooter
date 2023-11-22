using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string _nextScene = "Gameplay";

    public void StartGame()
    {
        SceneManager.LoadScene(_nextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
