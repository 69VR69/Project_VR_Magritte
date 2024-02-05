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
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        _inputManager ??= InputManager.Instance;
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        var val = _inputManager.TouchPad;

        //Calculer la vitesse du mouvement du joueur 
        //float xMov = Input.GetAxisRaw("Horizontal");
        //float yMov = Input.GetAxisRaw("Vertical");
        float xMov = val.x;
        float yMov = val.y;

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * yMov;

        Vector3 velocity = (moveVertical + moveHorizontal).normalized * speed;

        motor.Move(velocity);

        //calcul de la rotation du routeur en un Vector3
        Quaternion _rot = _camera.transform.rotation;

        motor.Rotate(_rot);
           
    }

    public void DisableMovement()
    {
        speed = 0;
    }
}
