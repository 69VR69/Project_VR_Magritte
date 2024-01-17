using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StemInteraction : Interactable
{
    public GameObject spawner;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Matchesbox"))
        { 
            spawner.GetComponent<FireOn>().IgniteFire();
        }
    }

    public override void Run(GameObject sender, InputManager inputManager)
    {
        base.Run(sender, inputManager);

        if (inputManager.IsTrigger)
        {
            Debug.Log("Stem triggered");
        }
    }
}