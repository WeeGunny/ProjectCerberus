using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Conversation myConversation;
    bool istalking = false;
    public bool isShopkeeper = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            dialogueManager.interactUI.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other) {

        if ((other.gameObject.tag == "Player")) {
            if (Input.GetKeyDown(KeyCode.E) && istalking == false ) {
                dialogueManager.StartDialog(myConversation);
                istalking = true;
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
            istalking = false;
        }
    }
}
