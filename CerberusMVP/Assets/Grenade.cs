using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3f;
    float destroyDelay = 3.1f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject HurtBox;
    public GameObject explosionEffect;

    float countdown;
    float destroyCountdown;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        destroyCountdown = destroyDelay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        destroyCountdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

        if (destroyCountdown <= 0f)
        {
            destroyObject();
        }
    }

    void Explode()
    {
        HurtBox.SetActive(true);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }

    void destroyObject()
    {
        Destroy(gameObject);
    }
}
