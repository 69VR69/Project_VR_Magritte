using UnityEngine;

namespace Assets.Script
{
    public class MockInteractions : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player; // Reference to the player XR rig
        [SerializeField]
        private float _speed = 0.01f; // Speed of the player XR rig
        private InputManager InputManager { get; set; } // Reference to the InputManager

        private void Start()
        {
            InputManager = InputManager.Instance;
            if (InputManager == null)
            {
                Debug.LogError("InputManager is null");
            }
            if (_player == null)
            {
                Debug.LogError("Player is null");
            }
        }

        // Define a set of interaction methods
        private void MoveForward() => _player.transform.position += _player.transform.forward * _speed;
        private void MoveBackward() => _player.transform.position -= _player.transform.forward * _speed;
        private void MoveLeft() => _player.transform.position -= _player.transform.right * _speed;
        private void MoveRight() => _player.transform.position += _player.transform.right * _speed;
        private void RotateLeft() => _player.transform.Rotate(0, -1, 0);
        private void RotateRight() => _player.transform.Rotate(0, 1, 0);
        private void RotateUp() => _player.transform.Rotate(-1, 0, 0);
        private void RotateDown() => _player.transform.Rotate(1, 0, 0);

        private void Update()
        {
            CheckMove();
            CheckRotate();
        }

        private void CheckMove()
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveBackward();
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveForward();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }
        }

        private void CheckRotate()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                RotateLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                RotateRight();
            }
            if (Input.GetKey(KeyCode.Z))
            {
                RotateUp();
            }
            if (Input.GetKey(KeyCode.S))
            {
                RotateDown();
            }
        }

    }
}