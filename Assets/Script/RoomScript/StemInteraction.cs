using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StemInteraction : Interactable
{
    public GameObject spawner;
    private bool hasIgnited;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("MatchesBox") && !hasIgnited)
        {
            Debug.Log("Collision with matches box");
            spawner.GetComponent<FireOn>().IgniteFire();
            hasIgnited = true;
        }
    }

}