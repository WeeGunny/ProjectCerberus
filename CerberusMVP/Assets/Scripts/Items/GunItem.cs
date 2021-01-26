using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : Item
{
    public GameObject gunPrefab;

    public override void OnPickup() {
        Debug.Log("Equiping Gun");
        FindObjectOfType<GunManager>().EquipGun(gunPrefab);
    }
    public override void OnBuy() {
        Debug.Log("Equiping Gun");
        FindObjectOfType<GunManager>().EquipGun(gunPrefab);
    }
}
