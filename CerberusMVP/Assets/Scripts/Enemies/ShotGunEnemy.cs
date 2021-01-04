using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunEnemy : EnemyController
{
    public float shotgunBullets, spread;
    protected override void Attack() {
        for (int i = 0; i < shotgunBullets; i++) {
            float spreadX = Random.Range(-spread, spread);
            float spreadY = Random.Range(-spread, spread);
            GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
            EnemyProjectile bulletProperties = bullet.GetComponent<EnemyProjectile>();
            Vector3 direction = transform.forward - new Vector3(spreadX, spreadY, 0);
            bullet.GetComponent<Rigidbody>().AddForce(direction*10,ForceMode.Impulse);
        }


    }
}
