using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armourer : NPC
{

    public override void ActivateNPC() {
        base.ActivateNPC();
        DialogueManager.dm.chatType = DialogueManager.ChatType.armourer;
    }

    public override void DeactivateNPC() {
        base.DeactivateNPC();
        DialogueManager.dm.chatType = DialogueManager.ChatType.Default;

    }
}
