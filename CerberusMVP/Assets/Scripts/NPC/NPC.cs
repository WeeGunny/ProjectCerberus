using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Conversation myConversation;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.StartDialog(myConversation);
        }
    }
}
