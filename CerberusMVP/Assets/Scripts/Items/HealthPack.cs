using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Item
{
    public float HealthAmount;

    public override void Use() {
        base.Use();
        PlayerManager.instance.stats.Health += HealthAmount;
    }
}
