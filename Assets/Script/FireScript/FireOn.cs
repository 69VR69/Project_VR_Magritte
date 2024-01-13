using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour
{

    public GameObject fire;
    

    // Update is called once per frame
    void Start()
    {
        Instantiate(fire, transform.position, transform.rotation);
    }
}
