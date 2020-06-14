using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Conversation myConversation;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") /*&& Input.GetButtonDown("Interact")*/)
        {
            dialogueManager.StartDialog(myConversation);

            //Enables mouse movement
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
