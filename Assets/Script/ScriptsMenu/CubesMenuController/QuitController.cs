using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitController : Interactable
{
    [SerializeField]
    
    public override void Run(GameObject sender, InputManager inputManager)
        {
            base.Run(sender, inputManager);

            if (inputManager.IsTrigger)
            {
                Debug.Log("Quitter");
                Application.Quit();
            }
        }
}
