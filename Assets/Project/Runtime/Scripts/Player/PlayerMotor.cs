using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    private Quaternion rotation;
    private Rigidbody rb;

    /// <summary>
    /// Initialise le rigidbody
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Déplace le joueur en fonction de la vélocité calculée
    /// </summary>
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    /// <summary>
    /// Fait tourner le joueur en fonction de la rotation calculée
    /// </summary>
    public void Rotate(Quaternion _rotation)
    {
        rotation = _rotation;
    }

    /// <summary>
    /// Applique les mouvements et rotations calculés
    /// </summary>
    private void FixedUpdate()
    {
        performMovement();
        performRotation();
    }

    /// <summary>
    /// Déplace le joueur
    /// </summary>
    private void performMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        rb.velocity = Vector3.zero;
    }

    /// <summary>
    /// Fait tourner le joueur
    /// </summary>
    private void performRotation()
    {
        rb.MoveRotation(rotation);

    }

}
