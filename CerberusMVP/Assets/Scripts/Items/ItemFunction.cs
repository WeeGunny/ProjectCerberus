using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunction : MonoBehaviour {

    protected virtual void Start() {
        LeanTween.rotateAround(this.gameObject, Vector3.up, 360, 3).setLoopClamp();
    }
    protected virtual void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (TryPickup()) Destroy(gameObject);
        }
    }
    public virtual bool TryPickup() {

        return false;
    }

    public virtual bool TryBuy() {

        return false;
    }

}
