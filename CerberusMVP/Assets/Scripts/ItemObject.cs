using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour {

    public Item item;

    public void OnPickup() {
        if (item.useType == UseType.Pickup) {
            item.Use();
        }
        else {
            bool wasPickedUp = Inventory.inventory.Add(item);
            if (wasPickedUp) {
                Debug.Log("You picked up: " + item.name);
                Destroy(gameObject);
            }
        }


    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Player") {
            if (item.useType == UseType.Pickup) {
                OnPickup();
            }

        }

    }
}
