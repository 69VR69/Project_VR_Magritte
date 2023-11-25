using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(BoxCollider),typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    private bool _isGrabbable = false;

    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();

        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody is null");
        }

        if (_collider == null)
        {
            Debug.LogError("Collider is null");
        }

        _rigidbody.useGravity = false;
        _collider.isTrigger = true;

        if (_isGrabbable)
        { 
            // add component XRGrabInteractable
            gameObject.AddComponent<XRGrabInteractable>();
        }
    }

    public void Run()
    {
        Debug.Log("Interactable is running");
    }
}
