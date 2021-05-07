using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class RebindKeys : MonoBehaviour {
    [SerializeField] private InputActionReference inputAction = null;
    [SerializeField] private TMP_Text bindingDisplayNameText = null;
    [SerializeField] private GameObject startRebindObject = null;
    [SerializeField] private GameObject waitingForInput = null;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    public DeviceDisplayManager displayManager;
    public Image ps4InputImage,xboxInputImage;
    bool showPC;


    public void Start() {
        ShowPCIcon();
    }

    public void StartRebinding() {

        startRebindObject.SetActive(false);
        waitingForInput.SetActive(true);

        if (showPC) {
            //sets the input binding to next hit excluding mouse movement and gamepad inputs
            rebindingOperation = inputAction.action.PerformInteractiveRebinding().
                       WithControlsExcluding("<Mouse>/Position").
                       WithControlsExcluding("<Mouse>/Delta").
                       WithControlsExcluding("<GamePad>").
                       OnMatchWaitForAnother(0.1f).
                       WithTargetBinding(0).
                       OnComplete(operation => RebindComplete()).
                       Start();
        }
        if (!showPC) {
            //sets the input binding to next hit excluding mouse, keyboard, and gamepad stick movement
            rebindingOperation = inputAction.action.PerformInteractiveRebinding().
                      WithControlsExcluding("<Mouse>").
                      WithControlsExcluding("<Keyboard>").
                      WithControlsExcluding("<Gamepad>/leftStick").WithControlsExcluding("<Gamepad>/rightStick").
                      OnMatchWaitForAnother(0.1f).
                      WithTargetBinding(1).
                      OnComplete(operation => RebindComplete()).
                      Start();

        }
       
    }

    private void RebindComplete() {
        if (showPC) {
            ShowPCIcon();
        }
        else {
            ShowGamePadIcons();
        }
        rebindingOperation.Dispose();
        startRebindObject.SetActive(true);
        waitingForInput.SetActive(false);


    }


    public void ShowPCIcon() {
        string bindingString = InputControlPath.ToHumanReadableString(inputAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        if(bindingDisplayNameText)bindingDisplayNameText.text = bindingString;
        ps4InputImage.gameObject.SetActive(false);
        xboxInputImage.gameObject.SetActive(false);
        showPC = true;
    }

    public void ShowGamePadIcons() {
        string bindingString = InputControlPath.ToHumanReadableString(inputAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        Sprite ps4Icon = displayManager.GetDeviceBindingIcon("Playstation", bindingString);
        Sprite xboxicon = displayManager.GetDeviceBindingIcon("Xbox", bindingString);
        if (ps4Icon) ps4InputImage.sprite = ps4Icon;
        else Debug.Log("no sprite grabbed: " + bindingString);
        if (xboxicon) xboxInputImage.sprite = xboxicon;
        ps4InputImage.gameObject.SetActive(true);
        xboxInputImage.gameObject.SetActive(true);
        if (bindingDisplayNameText) bindingDisplayNameText.text = "/";
        showPC = false;
    }

}
