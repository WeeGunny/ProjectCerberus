using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  

    public void onUse() {

    }

    public void onPickup() {

        Debug.Log("You picked up: " + gameObject.name );
    }

    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Player") {
            onPickup();
            Destroy(gameObject);
        }
        
    }
}
