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
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
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
        //float yRot = Input.GetAxisRaw("Mouse X");

        //Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivity;

        //motor.Rotate(rotation);
    }
}
