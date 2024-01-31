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
        Debug.Log("Revelation of the board : BedRoomScene");
        material.SetTexture("_MainTex", message);
    }
}
