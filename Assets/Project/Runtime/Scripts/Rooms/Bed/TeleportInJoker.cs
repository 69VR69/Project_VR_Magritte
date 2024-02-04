using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInJoker : Interactable
{
    private string _nextRoom;
    public override void Run(GameObject sender, InputManager inputManager)
        {
            base.Run(sender, inputManager);

            if (inputManager.IsTrigger)
            {
                Debug.Log($"Teleporting to {_nextRoom} through the teleporter \"{gameObject.name}\"");

                // Do the teleportation
                GameManager.Instance.SceneManager.ChangeSceneTo(_nextRoom);

            }
        }
}
