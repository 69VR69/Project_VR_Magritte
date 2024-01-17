using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour
{

    public GameObject fire;
    
    public void IgniteFire()
    {
        Instantiate(fire, transform.position, transform.rotation);
    }
}
