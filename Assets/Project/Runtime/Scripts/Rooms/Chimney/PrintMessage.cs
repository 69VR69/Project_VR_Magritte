using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintMessage : MonoBehaviour
{

    [SerializeField]
    Texture message;
    [SerializeField]
    Material material;
    [SerializeField]
    GameObject lastboard;   
    [SerializeField]
    GameObject newboard;


    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void ShowMessage()
    {
        material.SetTexture("_MainTex", message);
        lastboard.SetActive(false);
        newboard.SetActive(true);
    }
}
