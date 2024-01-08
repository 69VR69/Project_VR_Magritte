using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    private bool _isGrabbable = false;

    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private bool _isGrabbed = false;

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

        //if (_isGrabbable)
        //{
        //    // add component XRGrabInteractable
        //    gameObject.AddComponent<XRGrabInteractable>();
        //}
    }

    public void Run(GameObject sender, InputManager inputManager)
    {
        Debug.Log("Interactable is running");

        if (_isGrabbable)
        {
            if (inputManager.IsTrigger)
            {
                if (_isGrabbed)
                {
                    GetComponent<Renderer>().material.color = Color.yellow;
                    _rigidbody.useGravity = false;
                    _collider.isTrigger = true;
                    transform.SetParent(null);
                    _isGrabbed = false;
                }
                else
                {
                    GetComponent<Renderer>().material.color = Color.red;
                    _rigidbody.useGravity = false;
                    _collider.isTrigger = true;
                    transform.SetParent(sender.transform);
                    _isGrabbed = true;
                }
            }
        }
    }
}
