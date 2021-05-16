using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour, IInteractable
{
    public void Interact() {
        if (PlayerManager.player.GetComponent<rbPlayer>().hasBossKey) {
            UnlockBossDoor();
        }
        else {
            Debug.Log("You need the bossKey to enter this room");
        }
    }

    public void UnlockBossDoor() {
        gameObject.SetActive(false);
    }
}
