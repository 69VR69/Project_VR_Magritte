using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour
{

    public GameObject fire;

    /// <summary>
    /// Allume le feu
    /// </summary>
    public void IgniteFire()
    {
        Debug.Log("Ignite fire");
        GameObject spawner = GameObject.Find("SpawnerFire");

        // Instancie la flamme au même endroit et avec la même rotation que le spawner
        GameObject newFire = Instantiate(fire, transform.position, transform.rotation, spawner.transform);

        newFire.transform.localScale = spawner.transform.localScale;
        
    }
}
