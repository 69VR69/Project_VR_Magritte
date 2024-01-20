using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour
{

    public GameObject fire;
    
    public void IgniteFire()
    {
        Debug.Log("Ignite fire");
        GameObject spawner = GameObject.Find("SpawnerFire");

        // Instanciez la flamme au même endroit et avec la même rotation que le spawner
        GameObject newFire = Instantiate(fire, transform.position, transform.rotation, spawner.transform);

        // Ajustez l'échelle de la flamme pour qu'elle soit la même que celle du spawner
        newFire.transform.localScale = spawner.transform.localScale;
        
    }
}
