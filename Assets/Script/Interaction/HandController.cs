using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    private Animator _animator;
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _animator = GetComponent<Animator>();

        if (_inputManager == null)
        {
            Debug.LogError("InputManager is null");
        }

        if (_animator == null)
        {
            Debug.LogError("Animator is null");
        }
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
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            CheckAndRunInteraction(hit.collider);
    }

    private void CheckAndRunInteraction(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.TryGetComponent<Interactable>(out var interactable))
            {
                interactable.Run(gameObject, _inputManager);
            }
        }
    }
}
