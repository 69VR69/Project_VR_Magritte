using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public ConsoleToText consoleToText;
    private bool hasTouchedGround = false;
    private void Start()
    {
        consoleToText = FindObjectOfType<ConsoleToText>();
    }
    /// <summary>
    /// Lorsque le cube touche le sol, un message est ajouté à la console
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasTouchedGround && collision.gameObject.CompareTag("Ground"))
        {
            consoleToText.AddLog("Le cube a touché le sol");
            hasTouchedGround = true;  
        }
    }
    private void OnMouseDown()
    {
        consoleToText.AddLog("Le cube a été cliqué");
    }
}