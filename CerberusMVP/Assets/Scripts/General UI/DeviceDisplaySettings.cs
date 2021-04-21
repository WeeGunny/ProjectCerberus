using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CustomInputContextIcon
{
    public string customInputContextString;
    public Sprite customInputContextIcon;
}

[CreateAssetMenu(fileName = "Device Display Settings", menuName = "Scriptable Objects/Device Display Settings", order = 1)]
public class DeviceDisplaySettings : ScriptableObject
{

    public string deviceDisplayName;

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

}
