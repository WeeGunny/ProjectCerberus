using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunEnemy : EnemyController
{
    protected override void Attack() {
        GameObject bullet = Instantiate(projectile, gun.position, Quaternion.identity);
        EnemyProjectile bulletProperties = bullet.GetComponent<EnemyProjectile>();
        bulletProperties.direction = transform.forward - new Vector3(0, 0, 0);
        Debug.Log("Bullet1 Fired");
        
        ammo -= 1;
        GameObject bullet2 = Instantiate(projectile, gun.position, Quaternion.identity);
        EnemyProjectile bullet2Properties = bullet2.GetComponent<EnemyProjectile>();
        bullet2Properties.direction = transform.forward  - new Vector3(0,0.1f,0);
        Debug.Log("Bullet2 Fired");

        ammo -= 1;
        GameObject bullet3 = Instantiate(projectile, gun.position, Quaternion.identity);
        EnemyProjectile bullet3Properties = bullet3.GetComponent<EnemyProjectile>();
        bullet3Properties.direction = transform.forward  - new Vector3(0.1f,0,0);
        Debug.Log("Bullet3 Fired");

        ammo -= 1;
        GameObject bullet4 = Instantiate(projectile, gun.position, Quaternion.identity);
        EnemyProjectile bullet4Properties = bullet4.GetComponent<EnemyProjectile>();
        bullet4Properties.direction = transform.forward  - new Vector3(-0.1f,0,0);
        Debug.Log("Bullet4 Fired");

        ammo -= 1;
        GameObject bullet5 = Instantiate(projectile, gun.position, Quaternion.identity);
        EnemyProjectile bullet5Properties = bullet5.GetComponent<EnemyProjectile>();
        bullet5Properties.direction = (transform.forward) - new Vector3(0,0.1f,0);
        Debug.Log("Bullet5 Fired");
        ammo -= 1;
        GameObject bullet6 = Instantiate(projectile, gun.position, Quaternion.identity);
        EnemyProjectile bullet6Properties = bullet6.GetComponent<EnemyProjectile>();
        bullet6Properties.direction = transform.forward - new Vector3(0, -0.1f, 0);
        Debug.Log("Bullet6 Fired");
        ammo -= 1;

        attackDelay = attackDelay;
    }
}
