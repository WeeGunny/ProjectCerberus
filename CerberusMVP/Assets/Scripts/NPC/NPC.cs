using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable {
    public GameObject gameUI;
    public Conversation myConversation;
    public Conversation secondConversation;
    public Animator anim;

    protected virtual void Update() {
    }

    public virtual void ActivateNPC() {
        gameUI.SetActive(false);
        if(anim)anim.SetBool("isTalking", true);
        DialogueManager.dm.StartDialog(myConversation,this);
        Interacter.Interact?.Invoke();
        DialogueManager.dm.nextButton.SetActive(true);
    }

    public virtual void DeactivateNPC() {
        gameUI.SetActive(true);
        if(anim)anim.SetBool("isTalking", false);
        Interacter.EndInteract?.Invoke();
    }

    public virtual void Interact()
    {
        ActivateNPC();
    }
}
