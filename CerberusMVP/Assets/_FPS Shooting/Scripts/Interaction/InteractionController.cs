﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public LayerMask interactionLayer;

    PlayerInput input;
    InteractionControllerUI ui;
    Transform mainCamera;

    private void Start()
    {
        input = GetComponentInParent<PlayerInput>();

        ui = FindObjectOfType<InteractionControllerUI>();
        mainCamera = GetComponentInParent<CameraMovement>().transform;
        ui.SetCode(input.interactKey.ToString());
    }

    void Update()
    {
        Interactable interactWith = null;

        //First send a ray out forwards to hit anything
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out var hit, 10f))
        {
            //Get the distance then send another ray for only the interaction layer using that distance
            float dis = Vector3.Distance(mainCamera.position, hit.point) + 0.05f;

            if (Physics.Raycast(mainCamera.position, mainCamera.forward, out var interact, dis, interactionLayer))
            {
                Interactable inFront = interact.transform.GetComponent<Interactable>();
                if (inFront == null) return;
                if (dis > inFront.interactRange + 0.05f) return; //If the distance is greater than the interactable's range then return
                interactWith = inFront; //Set interactWith to the one we hit

                ui.UpdateInteract(interactWith.description);
                if (input.interact)
                    interactWith.Interact();
            }
        }

        ui.InteractableSelected(interactWith != null);
    }
}
