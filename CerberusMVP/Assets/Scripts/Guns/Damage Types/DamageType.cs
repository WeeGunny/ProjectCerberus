using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Damage Type")]
public class DamageType : ScriptableObject {
    public float dotDamage;
    public float dotTicks;
    public float dotInterval;
    public bool hasDOT;
}
