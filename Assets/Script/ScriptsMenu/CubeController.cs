using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public ConsoleToText consoleToText;

    private bool hasTouchedGround = false;

    private void Start()
    {
        // Assurez-vous de définir la référence à ConsoleToText dans l'éditeur Unity
        consoleToText = FindObjectOfType<ConsoleToText>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifiez si le cube touche le sol et que le message n'a pas déjà été affiché
        if (!hasTouchedGround && collision.gameObject.CompareTag("Ground"))
        {
            // Ajoutez un message à la console lorsque le cube touche le sol
            consoleToText.AddLog("Le cube a touché le sol");
            hasTouchedGround = true;  // Marquez que le message a été affiché
        }
    }
    private void OnMouseDown()
    {
        // Ajoutez un message à la console lorsque vous cliquez sur le cube
        consoleToText.AddLog("Le cube a été cliqué");
    }
}