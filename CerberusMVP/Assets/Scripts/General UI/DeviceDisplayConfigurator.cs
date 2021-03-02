using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Device Display Configurator", menuName = "Scriptable Objects/Device Display Configurator", order = 1)]
public class DeviceDisplayConfigurator : ScriptableObject
{
    
    [System.Serializable]
    public struct DeviceSet
    {
        public string deviceRawPath;
        public DeviceDisplaySettings deviceDisplaySettings;
    }

    public List<DeviceSet> listDeviceSets = new List<DeviceSet>();

    public Sprite GetDeviceBindingIcon(PlayerInput playerInput, string playerInputDeviceInputBinding)
    {

        string currentDeviceRawPath = playerInput.devices[0].ToString();

        Sprite displaySpriteIcon = null;

        for(int i = 0; i < listDeviceSets.Count; i++)
        {
            if(listDeviceSets[i].deviceRawPath == currentDeviceRawPath)
            {
                if(listDeviceSets[i].deviceDisplaySettings.deviceHasContextIcons != null)
                {
                    displaySpriteIcon = FilterForDeviceInputBinding(listDeviceSets[i], playerInputDeviceInputBinding);
                }
            }
        }

        return displaySpriteIcon;
    }

    Sprite FilterForDeviceInputBinding(DeviceSet targetDeviceSet, string inputBinding)
    {
        Sprite spriteIcon = null;

        switch(inputBinding)
        {
            case "Button North":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.buttonNorthIcon;  
                break;

            case "Button South":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.buttonSouthIcon;
                break;

            case "Button West":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.buttonWestIcon;
                break;

            case "Button East":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.buttonEastIcon;
                break;

            case "Right Shoulder":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.sholderRightIcon;
                break;

            case "Right Trigger":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.triggerRightIcon;
                break;

            case "rightTriggerButton":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.triggerRightIcon;
                break;

            case "Left Shoulder":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.shoulderLeftIcon;
                break;

            case "Left Trigger":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.triggerLeftIcon;
                break;

            case "leftTriggerButton":
                spriteIcon = targetDeviceSet.deviceDisplaySettings.triggerLeftIcon;
                break;

            default:

                for(int i = 0; i < targetDeviceSet.deviceDisplaySettings.customContextIcons.Count; i++)
                {
                    if(targetDeviceSet.deviceDisplaySettings.customContextIcons[i].customInputContextString == inputBinding)
                    {
                        if(targetDeviceSet.deviceDisplaySettings.customContextIcons[i].customInputContextIcon != null)
                        {
                            spriteIcon = targetDeviceSet.deviceDisplaySettings.customContextIcons[i].customInputContextIcon;
                        }
                    }
                }
                
                
                break;

        }

        return spriteIcon;
    }
}