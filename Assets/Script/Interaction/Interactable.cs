using UnityEngine;

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

    public virtual void Run(GameObject sender, InputManager inputManager)
    {
        Debug.Log($"Interaction with object {name} triggered");

        Renderer renderer = sender.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.gray;
        }
        else
        {
            Debug.LogWarning("Renderer not found on the game object.");
        }

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
