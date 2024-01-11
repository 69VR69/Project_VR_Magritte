using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*void Start()
    {
        
    }*/
    public string levelToLoad;
    public GameObject settingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);

    }

    public void SettingsButton()
    {
        ShowSettingsWindow();

    }

    public void QuitSettingsButton()
    {
        CloseSettingsWindow();

    }


    public void QuitGame()
    {
        Application.Quit();

    }

    private void ShowSettingsWindow()
    {
        if (settingsWindow != null)
        {
            settingsWindow.SetActive(true);
            Debug.Log("SettingsWindow shown");
        }
        else
        {
            Debug.LogError("SettingsWindow not assigned!");
        }
    }

    private void CloseSettingsWindow()
    {
        if (settingsWindow != null)
        {
            settingsWindow.SetActive(false);
            Debug.Log("SettingsWindow shown");
        }
        else
        {
            Debug.LogError("SettingsWindow not assigned!");
        }
    }


}