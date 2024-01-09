using UnityEngine;

namespace Assets.Script.Interaction
{
    public class Teleporter : Interactable
    {
        [SerializeField]
        private string _nextRoom;

        public override void Run(GameObject sender, InputManager inputManager)
        {
            base.Run(sender, inputManager);

            if (inputManager.IsTrigger)
            {
                // Do the teleportation
                GameManager.Instance.SceneManager.ChangeSceneTo(_nextRoom);
            }
        }
    }
}