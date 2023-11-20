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

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);

    }

    public void SettingsButton()
    {

    }

    public void QuitGame()
    {
        Application.Quit();

    }


}