using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;

using UnityEngine;
using UnityEngine.XR;

public class InputManager : MonoBehaviour
{
    public bool IsTrigger { get; set; } = false;
    public float TriggerValue { get; set; } = 0f;
    public bool IsBackButton { get; set; } = false;
    public float2 TouchPad { get; set; } = float2.zero;

    private InputDevice _controller;
    private bool _isControllerConnected = false;
    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    float value = 0f;
    Coroutine coroutine = null;

    private void Update()
    {
        GetPicoDevice();
        GetPicoInputs();

        // Mocked inputs for testing in the editor
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsTrigger = true;
                Debug.Log("[M]: Trigger pressed");
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                IsTrigger = false;
                Debug.Log("[M]: Trigger released");
            }

            coroutine ??= StartCoroutine(TriggerValueCoroutine());

            if (Input.GetKeyDown(KeyCode.B))
            {
                IsBackButton = true;
                Debug.Log("[M]: Back button pressed");
            }
            else if (Input.GetKeyUp(KeyCode.B))
            {
                IsBackButton = false;
                Debug.Log("[M]: Back button released");
            }

            TouchPad = new float2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    private IEnumerator TriggerValueCoroutine()
    {
        while (true)
        {
            Debug.Log("PUTE: " + TriggerValue);
            if (IsTrigger)
            {
                value += 0.1f;
                if (value > 1f)
                    value = 1f;
            }
            else
            {
                value -= 0.1f;
                if (value < 0f)
                    value = 0f;
            }

            TriggerValue = value;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void GetPicoDevice()
    {
        List<InputDevice> leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count <= 0)
            _isControllerConnected = false;

        if (!_isControllerConnected && leftHandDevices.Count == 1)
        {
            _controller = leftHandDevices[0];
            _isControllerConnected = true;
        }
    }

    // Get the values from a Pico VR controller
    private void GetPicoInputs()
    {
        if (_isControllerConnected)
        {
            if (_controller.TryGetFeatureValue(CommonUsages.triggerButton, out bool isTrigger))
            {
                IsTrigger = isTrigger;
            }

            if (_controller.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                TriggerValue = triggerValue;
            }

            if (_controller.TryGetFeatureValue(CommonUsages.menuButton, out bool backButtonValue))
            {
                IsBackButton = backButtonValue;
            }

            if (_controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 touchPadValue))
            {
                TouchPad = touchPadValue;
            }
        }
    }
}
