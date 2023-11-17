using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;


public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField]
    private Animator _handAnimator;
    private InputManager _inputManager;

    private void Awake() => _inputManager = InputManager.Instance;

    // Update is called once per frame
    void Update()
    {
        _handAnimator.SetBool("point", _inputManager.IsTrigger);
        _handAnimator.SetBool("grab", _inputManager.IsBackButton);
    }
}
