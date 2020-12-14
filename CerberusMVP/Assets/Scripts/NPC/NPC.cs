using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject gameUI;
    public Conversation myConversation;
    bool istalking = false;
    public bool isShopkeeper = false;
    public Animator anim;

    public static bool playerIsTalking;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            dialogueManager.interactUI.SetActive(true);
            gameUI.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other) {

        if ((other.gameObject.tag == "Player")) {
            if (Input.GetKeyDown(KeyCode.E) && !istalking) 
            {
                anim.SetBool("isTalking", true);
                dialogueManager.StartDialog(myConversation);
                istalking = true;
                playerIsTalking = true;
                if (isShopkeeper)
                {
                    dialogueManager.shopButton.SetActive(true);
                    dialogueManager.nextButton.SetActive(false);
                }
                else
                {
                    dialogueManager.shopButton.SetActive(false);
                    dialogueManager.nextButton.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if ((other.gameObject.tag == "Player")) {
            dialogueManager.interactUI.SetActive(false);
            gameUI.SetActive(true);
            istalking = false;
            playerIsTalking = false;
            anim.SetBool("isTalking", false);
        }
    }
}
