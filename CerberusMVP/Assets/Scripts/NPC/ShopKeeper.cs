using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : NPC {
    private float animationDelay = 5f;

    private int randInt;
    private bool isAnimating;

    private void Start() {
        gameUI = FindObjectOfType<PlayerStats>().gameObject;
    }
    protected override void Update() {
        base.Update();
        animationDelay -= Time.deltaTime;

        if (animationDelay <= 0f && !isAnimating) {
            isAnimating = true;
            randInt = Random.Range(0, 3);
            switch (randInt) {
                case 0:
                    Animation1();
                    break;
                case 1:
                    Animation2();
                    break;
                case 2:
                    Animation3();
                    break;
                default: break;
            }
        }

        if (anim.GetBool("isTalking")) {
            isAnimating = true;
        }

        if (!anim.GetBool("isTalking")) {
            isAnimating = false;
        }
    }

    void Animation1() {
        animationDelay = 10f;
        anim.SetTrigger("Foot");
        isAnimating = false;
    }

    void Animation2() {
        animationDelay = 8f;
        anim.SetTrigger("Happy");
        isAnimating = false;
    }

    void Animation3() {
        animationDelay = 6f;
        anim.SetTrigger("Head");
        isAnimating = false;
    }

    protected override void ActivateNPC() {
        base.ActivateNPC();
        DialogueManager.dm.chatType = DialogueManager.ChatType.shopKeeper;
    }

    protected override void DeactivateNPC() {
        base.DeactivateNPC();
        DialogueManager.dm.chatType = DialogueManager.ChatType.Default;

    }
}
