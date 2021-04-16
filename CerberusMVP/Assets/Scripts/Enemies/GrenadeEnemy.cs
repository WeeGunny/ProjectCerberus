using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeEnemy : GunnerEnemy
{

    protected override void Attack() {
        canAttack = false;
        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
        Vector3 direction = (target.transform.position - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);

        ammo -= 1;
        Invoke("AttackReset", attackDelay);
        AudioManager.audioManager.Play(fireClip, gameObject);
    }
}
