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
    [SerializeField]
    private Camera cam;

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

        // Vector3 moveHorizontal = transform.right * xMov;
        // Vector3 moveVertical = transform.forward * yMov;

        // Vector3 velocity = (moveVertical + moveHorizontal).normalized * speed;

        //camera direction
        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;

        camForward.y = 0; 
        camRight.y = 0;

        //create relate cam direction
        Vector3 forwardRelative = yMov * camForward;
        Vector3 rightRelative = xMov * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        Vector3 velocity = moveDir.normalized*speed;

        motor.Move(velocity);

        //calcul de la rotation du routeur en un Vector3
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivity;

        motor.Rotate(rotation);
           
    }
}
