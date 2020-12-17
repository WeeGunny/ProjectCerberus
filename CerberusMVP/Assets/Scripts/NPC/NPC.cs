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

        if (Input.GetKeyDown(KeyCode.E) && !istalking && playerInRange) ActivateNPC();


    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            dialogueManager.interactUI.SetActive(true);
            gameUI.SetActive(false);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            dialogueManager.interactUI.SetActive(false);
            gameUI.SetActive(true);
            istalking = false;
            playerIsTalking = false;
            anim.SetBool("isTalking", false);
            playerInRange = false;
        }
    }

    private void ActivateNPC() {
        anim.SetBool("isTalking", true);
        dialogueManager.StartDialog(myConversation);
        istalking = true;
        playerIsTalking = true;
        dialogueManager.nextButton.SetActive(true);


    }
}
