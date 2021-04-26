using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : ItemFunction
{

    public override bool TryPickup() {
        float randomGold = Mathf.Ceil(Random.Range(5, 10));
        PlayerManager.stats.gold += randomGold;
        return true;
    }

}
