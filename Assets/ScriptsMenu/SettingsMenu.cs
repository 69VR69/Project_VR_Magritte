
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject debugConsole;
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

        
    }



    public void SetDebugMode(bool isDebugMode)
    {
        if (isDebugMode)
        {
            ShowDebugConsole();
        }
        else
        {
            HideDebugConsole();
        }
    }

    private void ShowDebugConsole()
    {
        if (debugConsole == null)
        {
            debugConsole = GameObject.Find("Console"); 
            if (debugConsole == null)
            {
                Debug.LogError("Debug Console not found in the scene!");
                return;
            }
        }

        if (!debugConsole.activeSelf)
        {
            debugConsole.SetActive(true);
            Debug.Log("Debug Console shown");
        }
    }

    private void HideDebugConsole()
    {
        if (debugConsole == null)
        {
            debugConsole = GameObject.Find("Console"); 
            {
                Debug.LogError("Debug Console not found in the scene!");
                return;
            }
        }

        if (debugConsole.activeSelf)
        {
            debugConsole.SetActive(false);
            Debug.Log("Debug Console hidden");
        }
    }


    

    /*public void SetAccessibiiltyMode(bool isAccessibilitygMode)
    {

    }*/
}
