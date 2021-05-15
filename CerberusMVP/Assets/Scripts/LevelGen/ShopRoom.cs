using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRoom : Room {
    public GameObject Display1, Display2, Display3;
    bool displaysFilled =false;
    // Start is called before the first frame update
    void Start() {
        if (ShopUI.shopUI) {
            ShopUI.shopUI.FillDisplays(Display1, Display2, Display3);
            displaysFilled = true;
        }
       
    }

    // Update is called once per frame
    void Update() {

        if(displaysFilled == false && ShopUI.shopUI) {
            ShopUI.shopUI.FillDisplays(Display1, Display2, Display3);
            displaysFilled = true;
        }
    }
}
