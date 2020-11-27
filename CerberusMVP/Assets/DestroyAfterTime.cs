using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float delay = 3f;

    void Update()
    {
       delay -= Time.deltaTime;

        if (delay <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
