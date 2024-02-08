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
        ///Ajout des sources audio pour les sons
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

    /// <summary>
    /// Lorsque l'allumette entre en collision avec la boîte d'allumettes, le feu est allumé
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MatchesBox") && !hasIgnited)
        {
            Debug.Log("Collision avec la boîte d'allumettes");
            spawner.GetComponent<FireOn>().IgniteFire();
            hasIgnited = true;

            if (ignitionAudioSource != null && ignitionSound != null)
            {
                ignitionAudioSource.Play();
            }

            if (continuousAudioSource != null && continuousSound != null)
            {
                continuousAudioSource.loop = true;
                continuousAudioSource.Play();
            
            }
        }
    }
    /// <summary>
    /// Lorsque l'allumette est prise, le son de grab est joué
    /// </summary>
    public override void Run(GameObject sender, InputManager inputManager)
    {
        base.Run(sender, inputManager);

        if (inputManager.IsTrigger)
        {
            if (grabAudioSource != null && grabSound != null)
            {
                grabAudioSource.Play();
            }
        }
    }
    /// <summary>
    /// Arrête le son continu de l'allumette
    /// </summary>
    public void ExtinguishFire()
    {
        if (continuousAudioSource != null)
        {
            continuousAudioSource.Stop();
        }
    }
}
