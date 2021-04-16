using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable {
    public GameObject gameUI;
    public Conversation myConversation;
    bool playerInRange = false;
    public Animator anim;

    public static bool playerIsTalking;

    protected virtual void Update() {
    }

    public virtual void ActivateNPC() {
        gameUI.SetActive(false);
        if(anim)anim.SetBool("isTalking", true);
        DialogueManager.dm.StartDialog(myConversation,this);
        playerIsTalking = true;
        rbCam.LockCam();
        DialogueManager.dm.nextButton.SetActive(true);
    }

    public virtual void DeactivateNPC() {
        gameUI.SetActive(true);
        playerIsTalking = false;
        if(anim)anim.SetBool("isTalking", false);
        Interacter.instance.IsInteracting = false;
        rbCam.UnlockCam();

    }

    public virtual void Interact()
    {
        ActivateNPC();
        Interacter.instance.IsInteracting = true;
    }
}
