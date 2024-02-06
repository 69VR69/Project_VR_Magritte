using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    private bool _isGrabbable = false;

    private BoxCollider _collider;

    private bool _isGrabbed = false;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();

        if (_collider == null)
        {
            Debug.LogError("Collider is null");
        }

        _collider.isTrigger = true;
    }

    public virtual void Run(GameObject sender, InputManager inputManager)
    {
        Debug.Log($"Interaction with object {name} triggered");

        if (_isGrabbable)
        {
            if (inputManager.IsTrigger)
            {
                if (_isGrabbed)
                {
                    _collider.isTrigger = false;
                    transform.SetParent(null);
                    _isGrabbed = false;
                }
                else
                {
                    _collider.isTrigger = true;
                    transform.SetParent(sender.transform);
                    _isGrabbed = true;
                }
            }
        }
    }
}
