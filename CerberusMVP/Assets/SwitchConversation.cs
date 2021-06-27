using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchConversation : MonoBehaviour
{
    public NPC Jimbo;
    public GameObject gameUI;

    public void OnCollisionEnter(Collision col)
    {
        GameObject hit = col.gameObject;
        if (hit.tag == "Player")
        {
            Debug.Log("Collision detected!");
            Conversation Jimbo2 = Jimbo.secondConversation;
            DialogueManager.dm.StartDialog(Jimbo2, Jimbo);
            gameObject.SetActive(false);
            gameUI.SetActive(false);
            DialogueManager.dm.nextButton.SetActive(true);
        }
    }
}
