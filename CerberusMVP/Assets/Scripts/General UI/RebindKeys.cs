using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RebindKeys : MonoBehaviour {
    [SerializeField] private InputActionReference inputAction = null;
    [SerializeField] private TMP_Text bindingDisplayNameText = null;
    [SerializeField] private GameObject startRebindObject = null;
    [SerializeField] private GameObject waitingForInput = null;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;


    public void Start() {
        if (bindingDisplayNameText != null) {
            int bindingIndex = inputAction.action.GetBindingIndexForControl(inputAction.action.controls[0]);
            bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(inputAction.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
    }

    public void StartRebinding() {

        startRebindObject.SetActive(false);
        waitingForInput.SetActive(true);

        //sets the input binding to next hit excluding mouse movement inputs
        rebindingOperation = inputAction.action.PerformInteractiveRebinding().
            WithControlsExcluding("<Mouse>/Position").
            WithControlsExcluding("<Mouse>/Delta").
            OnMatchWaitForAnother(0.1f).
            OnComplete(operation => RebindComplete()).
            Start();


    }

    private void RebindComplete() {
        //Gets the first key binding for the action for current input device
        int bindingIndex = inputAction.action.GetBindingIndexForControl(inputAction.action.controls[0]);

        //sets rebind text to something readable
        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(inputAction.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        rebindingOperation.Dispose();

        startRebindObject.SetActive(true);
        waitingForInput.SetActive(false);


    }

}
