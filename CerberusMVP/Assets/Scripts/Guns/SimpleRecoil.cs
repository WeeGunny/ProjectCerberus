using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRecoil : MonoBehaviour
{
    public Vector3 upRecoil;
    Vector3 orignalRotation;

    // Start is called before the first frame update
    void Start()
    {
        orignalRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        upRecoil.Set(Random.Range(-5, -10), Random.Range(-1, 1), Random.Range(-1, 1));
    }

    public void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
        Invoke("StopRecoil", 0.2f);
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = orignalRotation;
    }
}
