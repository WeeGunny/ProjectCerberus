using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKey : ItemFunction
{
    public override bool TryPickup() {
        PlayerManager.player.GetComponent<rbPlayer>().hasBossKey = true;
        return true;
    }
}
