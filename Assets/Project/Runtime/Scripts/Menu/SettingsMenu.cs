
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

    /// <summary>
    /// Active ou désactive le mode débogage
    /// </summary>
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

    /// <summary>
    /// Affiche la console de débogage
    /// </summary>
    private void ShowDebugConsole()
    {
        if (debugConsole == null)
        {
            debugConsole = GameObject.Find("Console"); 
            if (debugConsole == null)
            {
                Debug.LogError("Debug Console pas trouvé dans le scène!");
                return;
            }
        }

        if (!debugConsole.activeSelf)
        {
            debugConsole.SetActive(true);
            Debug.Log("Debug Console montré");
        }
    }

    /// <summary>
    /// Cache la console de débogage
    /// </summary>
    private void HideDebugConsole()
    {
        if (debugConsole == null)
        {
            debugConsole = GameObject.Find("Console"); 
            {
                Debug.LogError("Debug Console pas trouvé dans la scène!");
                return;
            }
        }

        if (debugConsole.activeSelf)
        {
            debugConsole.SetActive(false);
            Debug.Log("Debug Console caché");
        }
    }

}
