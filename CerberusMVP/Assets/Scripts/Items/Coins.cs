using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Item
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.rotateAround(this.gameObject, Vector3.up, 360, 3).setLoopClamp();
    }

    public override void OnPickup() {
        PlayerStats.gold += 1;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
