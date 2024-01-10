using UnityEngine;

namespace Assets.Script.Interaction
{
    public class Teleporter : Interactable
    {
        public override void Run(GameObject sender, InputManager inputManager)
        {
            base.Run(sender, inputManager);

            if (inputManager.IsTrigger)
            {
                // Do the teleportation
            }
        }
    }
}