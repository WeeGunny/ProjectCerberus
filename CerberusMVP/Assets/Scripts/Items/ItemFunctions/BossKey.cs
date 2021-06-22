using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKey : ItemFunction
{
    public override bool TryPickup() {
        rbPlayer.Player.GetComponent<rbPlayer>().hasBossKey = true;
        return true;
    }
}
