using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        GameObject hit = col.gameObject;

        if (hit.tag == "Player")
        {
            resetTargets();
        }
    }

    void resetTargets()
    {
        Transform[] allchildren = this.transform.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < allchildren.Length; i++)
        {
            allchildren[i].gameObject.SetActive(true);
        }
    }
}
