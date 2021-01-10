using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public DialogueManager dialogueManager;
    public GameObject gameUI;
    public Conversation myConversation;
    bool playerInRange = false;
    bool istalking = false;
    public bool isShopkeeper = false;
    public Animator anim;

    public static bool playerIsTalking;

    private void Update() {

        if (Input.GetKeyDown(KeyCode.E) && !playerIsTalking && playerInRange) ActivateNPC();



    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            dialogueManager.interactUI.SetActive(true);       
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            dialogueManager.interactUI.SetActive(false);         
            playerInRange = false;
            DeactivateNPC();
        }
    }

    private void ActivateNPC() {
        gameUI.SetActive(false);
        anim.SetBool("isTalking", true);
        dialogueManager.StartDialog(myConversation);
        playerIsTalking = true;
        rbCam.LockCam();
        dialogueManager.nextButton.SetActive(true);
    }

    private void DeactivateNPC() {
        gameUI.SetActive(true);
        dialogueManager.StopDialog();
        playerIsTalking = false;
        anim.SetBool("isTalking", false);
        if (playerInRange) dialogueManager.interactUI.SetActive(false);
        rbCam.UnlockCam();

    }
}
