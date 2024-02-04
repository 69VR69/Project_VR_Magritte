using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitController : Interactable
{
    [SerializeField]
    public AudioClip grabSound;
    private AudioSource grabAudioSource;        
    private void Start()
    {
        grabAudioSource = gameObject.AddComponent<AudioSource>();   
        grabAudioSource.clip = grabSound;
    }
    
    public override void Run(GameObject sender, InputManager inputManager)
        {
            base.Run(sender, inputManager);

            if (inputManager.IsTrigger)
            {

                if (grabAudioSource != null && grabSound != null)
                {
                    grabAudioSource.Play();
                }
                Debug.Log("Quitter");
                Application.Quit();
            }
        }
}
