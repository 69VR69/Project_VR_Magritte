using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;

    /// <summary>
    /// Charge le niveau de jeu
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    /// <summary>
    /// Affiche la fenêtre des paramètres
    /// </summary>
    public void SettingsButton()
    {
        ShowSettingsWindow();

    }
    /// <summary>
    /// Quitte la fenêtre des paramètres
    /// </summary>
    public void QuitSettingsButton()
    {
        CloseSettingsWindow();

    }
    /// <summary>
    /// Quitte le jeu
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();

    }
    /// <summary>
    /// Affiche la fenêtre des paramètres
    /// </summary>
    private void ShowSettingsWindow()
    {
        if (settingsWindow != null)
        {
            settingsWindow.SetActive(true);
            Debug.Log("SettingsWindow montré");
        }
        else
        {
            Debug.LogError("SettingsWindow pas assigné!");
        }
    }
    /// <summary>
    /// Quitte la fenêtre des paramètres
    /// </summary>
    private void CloseSettingsWindow()
    {
        if (settingsWindow != null)
        {
            settingsWindow.SetActive(false);
            Debug.Log("SettingsWindow fermé");
        }
        else
        {
            Debug.LogError("SettingsWindow pas assigné!");
        }
    }


}