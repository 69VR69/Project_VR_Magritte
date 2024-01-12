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

            sender.GetComponent<Renderer>().material.color = Color.green;
            if (inputManager.IsTrigger)
            {
                sender.GetComponent<Renderer>().material.color = Color.yellow;
                // Do the teleportation
                GameManager.Instance.SceneManager.ChangeSceneTo(_nextRoom);
            }
        }
    }
}