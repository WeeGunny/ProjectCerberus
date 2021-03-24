using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelGuide : NPC
{
    public override void ActivateNPC() {
        base.ActivateNPC();
        DialogueManager.dm.chatType = DialogueManager.ChatType.travelGuide;
    }

    public override void DeactivateNPC() {
        base.DeactivateNPC();
        DialogueManager.dm.chatType = DialogueManager.ChatType.Default;

    }
}
