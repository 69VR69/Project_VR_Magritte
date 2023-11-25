using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HandAnimatorController : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    private Animator _animator;

    private void Awake()
    {
        //_inputManager = InputManager.Instance;
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
            float value = _inputManager.TriggerValue;
            Debug.Log("Trigger: " + value);
            float animValue = Mathf.Lerp(0f, 1f, value);
            _animator.SetFloat("Trigger", animValue);
        }
    }
}
