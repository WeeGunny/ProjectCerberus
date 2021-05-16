using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AirGun : Gun {

    public float blowBackRadius;
    public float blowRange;
    public float blowbackForce;
    public LayerMask whatIsTargets;


    public override void AltFire() {
        base.AltFire();

        RaycastHit[] hits = Physics.SphereCastAll(firePoint.position,blowBackRadius, firePoint.forward, blowRange,whatIsTargets);
        foreach(RaycastHit hit in hits) {
            if (hit.rigidbody) hit.rigidbody.AddForce(firePoint.forward * blowbackForce,ForceMode.Impulse);
            Debug.Log(hit.collider.gameObject.name);
        }

    }
}
