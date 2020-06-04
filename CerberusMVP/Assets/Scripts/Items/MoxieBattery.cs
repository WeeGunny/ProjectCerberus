using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoxieBattery : Item
{
    public float MoxieAmount;
    public override void Use() {
        base.Use();
        PlayerManager.instance.stats.Moxie += MoxieAmount;

    }
}
