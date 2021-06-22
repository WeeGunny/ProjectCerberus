using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : ItemFunction
{
    public override bool TryPickup() {
        if (PlayerStats.Instance.HealthPacks < PlayerStats.Instance.HealthPackMax) {
            AudioManager.audioManager.Play("Item Pickup", rbPlayer.Player.gameObject);
            PlayerStats.Instance.HealthPacks += 1;
            return true;
        }
        else {
            return false;
        }
    }

    public override bool TryBuy() {
        if (PlayerStats.Instance.HealthPacks < PlayerStats.Instance.HealthPackMax) {
            PlayerStats.Instance.HealthPacks += 1;
            return true;
        }
        else {
            return false;
        }
    }
}
