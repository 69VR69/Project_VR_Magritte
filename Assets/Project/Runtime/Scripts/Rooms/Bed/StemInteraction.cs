using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class StemInteraction : Interactable
{
    public GameObject spawner;
    private bool hasIgnited;
    public AudioClip ignitionSound;      // Son lors de l'allumage
    public AudioClip continuousSound;    // Son feu continu
    public AudioClip grabSound;          // Son de grab
    private AudioSource ignitionAudioSource;
    private AudioSource continuousAudioSource;
    private AudioSource grabAudioSource;

    private void Start()
    {

        ignitionAudioSource = gameObject.AddComponent<AudioSource>();
        ignitionAudioSource.clip = ignitionSound;
        ignitionAudioSource.playOnAwake = false;
        ignitionAudioSource.Stop();
        continuousAudioSource = gameObject.AddComponent<AudioSource>();
        continuousAudioSource.clip = continuousSound;
        
        continuousAudioSource.playOnAwake = false;
        continuousAudioSource.Stop();
        grabAudioSource = gameObject.AddComponent<AudioSource>();
        grabAudioSource.clip = grabSound;
        grabAudioSource.playOnAwake = false;
        grabAudioSource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MatchesBox") && !hasIgnited)
        {
            Debug.Log("Collision with matches box");
            spawner.GetComponent<FireOn>().IgniteFire();
            hasIgnited = true;

            if (ignitionAudioSource != null && ignitionSound != null)
            {
                Debug.Log("allumage alumette");
                ignitionAudioSource.Play();
            }

            if (continuousAudioSource != null && continuousSound != null)
            {
                Debug.Log("son allumette");
                continuousAudioSource.loop = true;
                continuousAudioSource.Play();
            
            }
        }
    }

    public override void Run(GameObject sender, InputManager inputManager)
    {
        base.Run(sender, inputManager);

        if (inputManager.IsTrigger)
        {
            Debug.Log("Son pour grab");
            if (grabAudioSource != null && grabSound != null)
            {
                grabAudioSource.Play();
            }
        }
    }
    // appeler cette méthode pour arrêter le son continu lorsque l'allumette est éteinte
    public void ExtinguishFire()
    {
        if (continuousAudioSource != null)
        {
            continuousAudioSource.Stop();
        }
    }
}
