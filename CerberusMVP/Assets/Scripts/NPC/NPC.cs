using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public GameObject gameUI;
    public Conversation myConversation;
    bool playerInRange = false;
    public Animator anim;

    public static bool playerIsTalking;


    protected virtual void Update() {

        if (Input.GetKeyDown(KeyCode.E) && !playerIsTalking && playerInRange) ActivateNPC();

    }

    protected void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            DialogueManager.dm.interactUI.SetActive(true);
            playerInRange = true;
        }
    }

    protected void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            DialogueManager.dm.interactUI.SetActive(false);
            playerInRange = false;
            DeactivateNPC();
        }
    }

    protected virtual void ActivateNPC() {
        gameUI.SetActive(false);
        if(anim)anim.SetBool("isTalking", true);
        DialogueManager.dm.StartDialog(myConversation);
        playerIsTalking = true;
        rbCam.LockCam();
        DialogueManager.dm.nextButton.SetActive(true);
    }

    protected virtual void DeactivateNPC() {
        gameUI.SetActive(true);
        DialogueManager.dm.StopDialog();
        playerIsTalking = false;
        if(anim)anim.SetBool("isTalking", false);
        if (playerInRange) DialogueManager.dm.interactUI.SetActive(true);
        rbCam.UnlockCam();

    }
}
