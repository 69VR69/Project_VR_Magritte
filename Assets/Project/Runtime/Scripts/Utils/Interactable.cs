using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    private bool _isGrabbable = false;

    private BoxCollider _collider;

    private bool _isGrabbed = false;

    private Outliner _outline;

    private void Awake()
    {
        _outline = GetComponentInChildren<Outliner>();
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

        // Activate outline if exists
        if (_outline != null)
        {
            _outline.ActiveOutline();
        }

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
