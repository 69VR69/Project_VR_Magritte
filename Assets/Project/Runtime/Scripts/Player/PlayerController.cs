using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float mouseSensitivity = 3f;
    [SerializeField]
    private InputManager _inputManager;

    private PlayerMotor motor;
    private Camera _camera;
    

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        _inputManager ??= InputManager.Instance;
        _camera = Camera.main;
    }

    
    void Update()
    {

        var val = _inputManager.TouchPad;

        float xMov = val.x;
        float yMov = val.y;

        // Calcule la direction du mouvement en fonction de la rotation de la caméra
        Vector3 cameraForward = _camera.transform.forward;
        Vector3 cameraRight = _camera.transform.right;

        // Calcule le déplacement du joueur en fonction de la direction de la caméra
        Vector3 moveDirection = (cameraForward * yMov + cameraRight * xMov).normalized;

        moveDirection.y = 0;

        Vector3 velocity = moveDirection * speed;

        motor.Move(velocity);
        
    }

    public void DisableMovement()
    {
        speed = 0;
    }
}

