using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintMessage : MonoBehaviour
{

    [SerializeField]
    Texture message;
    [SerializeField]
    Material material;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void ShowMessage()
    {
        material.SetTexture("_MainTex", message);
    }
}
