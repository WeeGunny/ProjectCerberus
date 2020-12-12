﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : Item
{
    public float ammoAmount;

    public override void Use() {
        base.Use();
        PlayerManager.stats.activeGun.currentAmmo += ammoAmount;
    }

}
