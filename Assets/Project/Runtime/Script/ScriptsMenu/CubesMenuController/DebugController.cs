using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DebugController : Interactable
{
    [SerializeField]
    public GameObject debugConsole;
    public override void Run(GameObject sender, InputManager inputManager)
        {
            base.Run(sender, inputManager);

            if (inputManager.IsTrigger)
            {
                if (debugConsole == null)
                {
                    debugConsole = GameObject.Find("Console"); 
                    if (debugConsole == null)
                    {
                        Debug.LogError("Debug Console not found in the scene!");
                        return;
                    }
                }

                if (!debugConsole.activeSelf)
                {
                    debugConsole.SetActive(true);
                    Debug.Log("Debug Console shown");
                }
            }
        }
}
