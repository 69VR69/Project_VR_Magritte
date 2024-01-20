using System.Collections;
using System.Collections.Generic;

using Unity.XR.CoreUtils;

using UnityEngine;

public class HandController : MonoBehaviour
{
    private InputManager _inputManager;
    private Animator _animator;
    private BoxCollider _collider;
    [SerializeField]
    private GameObject _handRay;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();

        if (_inputManager == null)
            _inputManager = InputManager.Instance;

        if (_animator == null)
            Debug.LogError("Animator is null");

        if (_handRay == null)
            Debug.LogError("HandRay is null");
    }

    private void Update()
    {
        if (_animator != null && _inputManager != null)
        {
            AnimateHand();

            if (_inputManager.TriggerValue > 0.5f)
                _collider.enabled = true;
            else
                _collider.enabled = false;
        }

        SendRayCast();
    }

    private void AnimateHand() =>
        _animator.SetFloat("Trigger", Mathf.Lerp(0f, 1f, _inputManager.TriggerValue));

    private void OnTriggerEnter(Collider other) => CheckAndRunInteraction(other);
    private void SendRayCast()
    {
        // Align the ray with the VR controller's ray
        Vector3 origin = transform.position;
        Vector3 direction = _handRay.transform.forward;

        if (Physics.Raycast(origin, direction, out RaycastHit hit))
            CheckAndRunInteraction(hit.collider);
    }

    private void CheckAndRunInteraction(Collider other)
    {
        if (other.CompareTag("Interactable"))
            if (other.TryGetComponent<Interactable>(out var interactable))
                interactable.Run(gameObject, _inputManager);
    }

    private void OnDrawGizmos()
    {
        if (_handRay != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, _handRay.transform.forward);

        }
    }
}
