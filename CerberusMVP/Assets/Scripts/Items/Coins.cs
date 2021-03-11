using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : ItemFunction
{

    public override bool TryPickup() {
        PlayerStats.gold += 1;
        return true;
    }

}
