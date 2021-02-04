using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerEnemy : EnemyController
{
    public int maxAmmo = 20;
    public float bulletSpeed =5;
    protected int ammo = 20;
    public float reloadDelay = 1.5f;

    protected override void Update() {
        if (ammo <= 0) {
            anim.SetBool("outOfAmmo", true);
            StartCoroutine(Reload());
        }
        base.Update();
       
    }
    protected override void Attack() {
        canAttack = false;
        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
        Vector3 direction = (target.position - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed , ForceMode.Impulse);

        ammo -= 1;
        Invoke("AttackReset", attackDelay);
    }

    protected IEnumerator Reload() {
        canAttack = false;
        yield return new WaitForSeconds(reloadDelay);
        ammo = maxAmmo;
        isReloading = false;
        anim.SetBool("outOfAmmo", false);
        canAttack = true;
    }
}
