using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayController : Interactable
{

    [SerializeField]
    public string levelToLoad;
    public override void Run(GameObject sender, InputManager inputManager)
        {
            base.Run(sender, inputManager);

            if (inputManager.IsTrigger)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
}
