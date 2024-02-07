using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    private Quaternion rotation;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Quaternion _rotation)
    {
        rotation = _rotation;
    }

    private void FixedUpdate()
    {
        performMovement();
        performRotation();
    }

    private void performMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        rb.velocity = Vector3.zero;
    }

    private void performRotation()
    {
        rb.MoveRotation(rotation);

    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMotor : MonoBehaviour
// {
//     private Vector3 velocity;
//     private Rigidbody rb;

//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     public void Rotate(Quaternion toRotation)
//     {
//         rb.MoveRotation(toRotation);
//     }

//     public void Move(Vector3 _velocity)
//     {
//         velocity = _velocity;
//     }

//     void FixedUpdate()
//     {
//         PerformMovement();
//     }

//     private void PerformMovement()
//     {
//         if(velocity != Vector3.zero)
//         if (velocity != Vector3.zero)
//         {
//             rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
//         }
//         rb.velocity = Vector3.zero;
//     }

// }