using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class TriggerPullEvent : UnityEvent<bool> { }

public class TriggerPullWatcher : MonoBehaviour
{
    public TriggerPullEvent triggerPullLeft;
    public TriggerPullEvent triggerPullRight;

    private bool lastTriggerStateL = false;
    private bool lastTriggerStateR = false;

    private List<InputDevice> devicesWithTriggerL;
    private List<InputDevice> devicesWithTriggerR;

    private void Awake()
    {
        if (triggerPullLeft == null)
        {
            triggerPullLeft = new TriggerPullEvent();
        }
        if (triggerPullRight == null)
        {
            triggerPullRight = new TriggerPullEvent();
        }

        devicesWithTriggerL = new List<InputDevice>();
        devicesWithTriggerR = new List<InputDevice>();
    }

    void OnEnable()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        foreach (InputDevice device in devices)
            InputDevices_DeviceConnected(device);

        InputDevices.deviceConnected += InputDevices_DeviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_DeviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithTriggerL.Clear();
        devicesWithTriggerR.Clear();
    }

    private void InputDevices_DeviceConnected(InputDevice device)
    {
        List<InputDevice> leftDevices = new List<InputDevice>();
        List<InputDevice> rightDevices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, leftDevices);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, rightDevices);

        bool discardedValue;
        
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out discardedValue) && leftDevices.Contains(device))
        {
            devicesWithTriggerL.Add(device); // Add any devices that have a primary button.
        }
        else if (device.TryGetFeatureValue(CommonUsages.triggerButton, out discardedValue) && rightDevices.Contains(device))
        {
            devicesWithTriggerR.Add(device); // Add any devices that have a primary button.
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithTriggerL.Contains(device))
            devicesWithTriggerL.Remove(device);
        if (devicesWithTriggerR.Contains(device))
            devicesWithTriggerR.Remove(device);
    }

    void Update()
    {
        bool tempStateL = false;
        bool tempStateR = false;
        foreach (var device in devicesWithTriggerL)
        {
            bool triggerStateL = false;
            tempStateL = device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerStateL) // did get a value
                        && triggerStateL // the value we got
                        || tempStateL; // cumulative result from other controllers
        }
        
        if (tempStateL != lastTriggerStateL) // Button state changed since last frame
        {
            triggerPullLeft.Invoke(tempStateL);
            lastTriggerStateL = tempStateL;
        }

        foreach (var device in devicesWithTriggerR)
        {
            bool triggerStateR = false;
            tempStateR = device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerStateR) // did get a value
                        && triggerStateR // the value we got
                        || tempStateR; // cumulative result from other controllers
        }

        if (tempStateR != lastTriggerStateR) // Button state changed since last frame
        {
            triggerPullRight.Invoke(tempStateR);
            lastTriggerStateR = tempStateR;
        }
    }
}