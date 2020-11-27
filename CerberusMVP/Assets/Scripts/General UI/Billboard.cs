using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //public Transform cam;

    //Allows camera to perform movement and then point UI element towards it afterwards
    void LateUpdate()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        transform.Rotate(0, 180, 0);
    }
}
