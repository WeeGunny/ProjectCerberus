using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunDelay : MonoBehaviour
{
    public Transform minigunBarrel;
    public float maxSpinSpeed = 90f;
    float tillShooting = 0;
    float speed = 0;

    void Start()
    {
        GunHandlerListener listener = GetComponent<GunHandlerListener>();
        if (!listener) return;
        tillShooting = listener.getDelayTime();
        listener.onDelay.AddListener(DelayMinigun);
    }

    private void Update()
    {
        minigunBarrel.Rotate(speed * Time.deltaTime, 0, 0);
    }

    public void DelayMinigun(float t)
    {
        if (tillShooting <= 0) return;
        speed = Mathf.Clamp(t, 0, tillShooting) / tillShooting;
        speed *= maxSpinSpeed;
    }
}
