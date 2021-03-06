﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string itemName;
    [TextArea(3,10)]
    public string description;
    public Sprite icon = null;
    public float cost;
    public bool shopItem;
    [HideInInspector] public GameObject itemObject;

    private void Start() {
        itemObject = gameObject;
    }

    protected virtual void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !shopItem) {
            OnPickup();
        }
    }

    public virtual void OnPickup() {
    }

    public virtual void OnBuy() {

    }
}
