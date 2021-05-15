using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour {
    public List<RebindKeys> rebinds = new List<RebindKeys>();


    public void DisplayKeyboardRebinds() {
        foreach(RebindKeys rebind in rebinds) {
            rebind.ShowPCIcon();
        }
    }

    public void DisplayGamepadRebinds() {
        foreach (RebindKeys rebind in rebinds) {
            rebind.ShowGamePadIcons();
        }
    }
}
