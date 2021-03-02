using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunEnemy : GunnerEnemy
{
    public float shotgunBullets, spread;
    protected override void Attack() {

        canAttack = false;
        for (int i = 0; i < shotgunBullets; i++) {
            float spreadX = Random.Range(-spread, spread);
            float spreadY = Random.Range(-spread, spread);
            GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
            EnemyProjectile bulletProperties = bullet.GetComponent<EnemyProjectile>();
            Vector3 direction = (target.position -firePoint.position) - new Vector3(spreadX, spreadY, 0);
            bullet.GetComponent<Rigidbody>().AddForce(direction*bulletSpeed/100,ForceMode.Impulse);
        }
        ammo -= 1;
        Invoke("AttackReset", attackDelay);

    }
}
