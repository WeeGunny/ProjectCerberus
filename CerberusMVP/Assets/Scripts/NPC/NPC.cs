using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable {
    public GameObject gameUI;
    public Conversation myConversation;
    public Conversation secondConversation;
    public Animator anim;

    public static bool playerIsTalking;

    protected virtual void Update() {
    }

    public virtual void ActivateNPC() {
        gameUI.SetActive(false);
        if(anim)anim.SetBool("isTalking", true);
        DialogueManager.dm.StartDialog(myConversation,this);
        playerIsTalking = true;
        if (Interacter.instance) Interacter.instance.IsInteracting = true;
        DialogueManager.dm.nextButton.SetActive(true);
    }

    public virtual void DeactivateNPC() {
        gameUI.SetActive(true);
        playerIsTalking = false;
        if(anim)anim.SetBool("isTalking", false);
        if (Interacter.instance) Interacter.instance.IsInteracting = false;
    }

    public virtual void Interact()
    {
        ActivateNPC();
    }
}
