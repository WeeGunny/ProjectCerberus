using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Damage Type")]
public class DamageType : ScriptableObject {
    public float dotDamage;
    public float dotTicks;
    public float dotInterval;
    public bool hasDOT;

    IEnumerator DotDamage(EnemyController enemy) {
        enemy.takingDotDamage = true;
        int ticksApplied = 0;
        while (ticksApplied < dotTicks) {
            enemy.health -= dotDamage;
            yield return new WaitForSeconds(dotInterval);
            ticksApplied++;
        }
        enemy.takingDotDamage = false;
    }
}
