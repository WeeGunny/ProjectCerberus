using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interacter : MonoBehaviour {
    public float InteractRange;
    public static bool CanInteract;
    public static IInteractable interactableObject;

    public static Action Interact = () => { CanInteract = false; GameUI.ToggleUI(false); };
    public static Action EndInteract = () => { CanInteract = true; GameUI.ToggleUI(true); };
    // Start is called before the first frame update

    private void Update()
    {
        InteractUI.instance.ToggleUI(CheckForInteractable() && CanInteract);
    }

    public bool CheckForInteractable() {
        Ray ray = rbCam.PlayerCam.ViewportPointToRay(new Vector3(.5f, .5f, 0), rbCam.PlayerCam.stereoActiveEye); // goes to center of screen;
        RaycastHit hit;
        Physics.Raycast(ray, out hit, InteractRange);
        if (hit.collider) {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null) {
                interactableObject = interactable;
                return true;
            }
        }
        interactableObject = null;
        return false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        if (rbCam.PlayerCam) Gizmos.DrawLine(rbCam.PlayerCam.transform.position, rbCam.PlayerCam.ViewportPointToRay(new Vector3(.5f, .5f, 0)).GetPoint(InteractRange));
    }
}
