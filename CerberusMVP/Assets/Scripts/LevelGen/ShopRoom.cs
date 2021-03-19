using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRoom : Room {
    public GameObject Display1, Display2, Display3;
    // Start is called before the first frame update
    void Start() {
        ShopUI.shopUI.FillDisplays(Display1, Display2, Display3);
    }

    // Update is called once per frame
    void Update() {

    }
}
