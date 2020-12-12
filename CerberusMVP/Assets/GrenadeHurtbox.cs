using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeHurtbox : MonoBehaviour
{
    public float damage = 30;


    private void OnTriggerEnter(Collider col)
    {
        GameObject other = col.gameObject;
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            PlayerManager.stats.TakeDamage(damage);
        }
    }
}
