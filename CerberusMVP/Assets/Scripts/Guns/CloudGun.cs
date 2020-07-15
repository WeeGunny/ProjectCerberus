using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGun : PlayerProjectile {

    public GameObject CloudPrefab;

    protected override void Update() {
        float distance = Vector3.Distance(origin, transform.position);
        if (distance >= range) {
            Debug.Log("Projectile Ranged out");
            DestroyProjectile();
            CreateCloud(transform.position);
        }
    }
    protected override void OnCollisionEnter(Collision collision) {
        DestroyProjectile();
        CreateCloud(collision.GetContact(0).point);
    }

    public void CreateCloud(Vector3 SpawnPoint) {
        Instantiate(CloudPrefab,SpawnPoint,Quaternion.identity);
        
    }
}
