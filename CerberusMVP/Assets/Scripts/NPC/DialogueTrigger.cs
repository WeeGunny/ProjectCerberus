using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(Collider other)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            //StartDialogue();
        }
    }

}
