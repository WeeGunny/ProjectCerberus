using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CustomInputContextIcon {
    public string customInputContextString;
    public Sprite customInputContextIcon;
}

[CreateAssetMenu(fileName = "Device Display Settings", menuName = "Scriptable Objects/Device Display Settings", order = 1)]
public class DeviceDisplaySettings : ScriptableObject {

    public string deviceDisplayName;
    public string deviceRawPath;

    public Color deviceDisplayColor;

    public bool deviceHasContextIcons;

    public Sprite buttonNorthIcon;
    public Sprite buttonSouthIcon;
    public Sprite buttonWestIcon;
    public Sprite buttonEastIcon;

    public Sprite sholderRightIcon;
    public Sprite triggerRightIcon;
    public Sprite shoulderLeftIcon;
    public Sprite triggerLeftIcon;

    public Sprite startButton;
    public Sprite selectButton;

    public Sprite dpad;
    public Sprite dpadUp;
    public Sprite dpadDown;
    public Sprite dpadLeft;
    public Sprite dpadRight;

    public Sprite leftStick;
    public Sprite rightStick;
    public Sprite leftStickPress;
    public Sprite rightStickPress;

    public List<CustomInputContextIcon> customContextIcons = new List<CustomInputContextIcon>();

    public Sprite GetInputIcon(string inputBinding) {
        Sprite spriteIcon = null;

        switch (inputBinding) {
            case "Button North":
                spriteIcon = buttonNorthIcon;
                break;

            case "Button South":
                spriteIcon = buttonSouthIcon;
                break;

            case "Button West":
                spriteIcon = buttonWestIcon;
                break;

            case "Button East":
                spriteIcon = buttonEastIcon;
                break;

            case "Right Shoulder":
                spriteIcon = sholderRightIcon;
                break;

            case "Right Trigger":
                spriteIcon = triggerRightIcon;
                break;

            case "rightTriggerButton":
                spriteIcon = triggerRightIcon;
                break;

            case "Left Shoulder":
                spriteIcon = shoulderLeftIcon;
                break;

            case "Left Trigger":
                spriteIcon = triggerLeftIcon;
                break;

            case "leftTriggerButton":
                spriteIcon = triggerLeftIcon;
                break;
            case "Start":
                spriteIcon = startButton;
                break;
            case "Select Button":
                spriteIcon = selectButton;
                break;
            case "Dpad":
                spriteIcon = dpad;
                break;
            case "D-Pad/Up":
                spriteIcon = dpadUp;
                break;
            case "D-Pad/Down":
                spriteIcon = dpadDown;
                break;
            case "D-Pad/Left":
                spriteIcon = dpadLeft;
                break;
            case "D-Pad/Right":
                spriteIcon = dpadRight;
                break;
            case "Left Stick":
                spriteIcon = leftStick;
                break;
            case "Right Stick":
                spriteIcon = rightStick;
                break;
            case "Left Stick Press":
                spriteIcon = leftStickPress;
                break;
            case "Right Stick Press":
                spriteIcon = rightStickPress;
                break;

            default:
                for (int i = 0; i < customContextIcons.Count; i++) {
                    if (customContextIcons[i].customInputContextString == inputBinding) {
                        if (customContextIcons[i].customInputContextIcon != null) {
                            spriteIcon = customContextIcons[i].customInputContextIcon;
                        }
                    }
                }
                break;

        }

        return spriteIcon;
    }

}
