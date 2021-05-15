using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        GameObject hit = col.gameObject;
        if (hit.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }
}
