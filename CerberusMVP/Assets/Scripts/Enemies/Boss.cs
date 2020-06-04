using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyController
{
 
    protected override void Death() {
        base.Death();
        Debug.Log("You killed the BOSS! You can now exit the level");
        LevelExit.CanExit = true;
    }
}
