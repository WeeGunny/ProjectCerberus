using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Device Display Manager", menuName = "Scriptable Objects/Device Display Manager", order = 1)]
public class DeviceDisplayManager : ScriptableObject
{
    
    [System.Serializable]
    public struct DeviceSet
    {
        public string deviceName;
        public DeviceDisplaySettings deviceDisplaySettings;
    }

    public List<DeviceSet> listDeviceSets = new List<DeviceSet>();

    public Sprite GetDeviceBindingIcon(string deviceName, string playerInputBinding)
    {

        Sprite displaySpriteIcon = null;

        for(int i = 0; i < listDeviceSets.Count; i++)
        {
            if(listDeviceSets[i].deviceName == deviceName)
            {
                displaySpriteIcon = listDeviceSets[i].deviceDisplaySettings.GetInputIcon(playerInputBinding);
            }
        }

        return displaySpriteIcon;
    }
}