using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;

using UnityEngine;
using UnityEngine.XR;

public class InputManager : MonoBehaviour
{
    public bool IsTrigger { get; set; }
    public bool IsBackButton { get; set; }
    public float2 TouchPad { get; set; }

    private InputDevice _controller;
    private bool _isControllerConnected = false;

    private void Update()
    {
        GetPicoDevice();
        GetPicoInputs();
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
            if (_controller.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue))
            {
                IsTrigger = triggerValue;
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
