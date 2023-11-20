
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        
    }

    public void SetDebugMode(bool isDebugMode)
    {
        if (isDebugMode){
            Debug.Log("check");
        }
        else
        {
            Debug.Log("nocheck");
        }
        

    }

    /*public void SetAccessibiiltyMode(bool isAccessibilitygMode)
    {

    }*/
}
