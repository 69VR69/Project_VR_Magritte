using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour
{

    public GameObject fire;
    
    public void IgniteFire()
    {
        Debug.Log("Ignite fire");
        Debug.Log(fire.name);
        Instantiate(fire, transform.position, transform.rotation);
    }
}
