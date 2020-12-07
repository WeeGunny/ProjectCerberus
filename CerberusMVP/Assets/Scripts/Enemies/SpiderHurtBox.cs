using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHurtBox : MonoBehaviour
{
    public float damage = 15;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            PlayerManager.instance.stats.TakeDamage(damage);
        }
    }
}
