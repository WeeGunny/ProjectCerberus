using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : ItemFunction {

    public GunInfo itemGun;

    public override bool TryBuy() {
        if (Armory.UnlockedWeapons.Contains(itemGun) && PlayerStats.Instance.CurrentGun == itemGun.gun) {
            return false;
        }
        if (!Armory.UnlockedWeapons.Contains(itemGun)) {
            Armory.UnlockedWeapons.Add(itemGun);
            Armory.armory.RefreshGunList();
        }
        EquipGun();
        return true;

    }

    public override bool TryPickup() {
        if (PlayerStats.Instance.CurrentGun == itemGun.gun && GunManager.instance.secondaryGunObject) return false;
        EquipGun();
        return true;
    }

    public void EquipGun() {
        GunManager.instance.EquipGun(itemGun);
    }
}
