﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PooledObject : MonoBehaviour
{
    public float autoPool = 100f;
    private bool inPool = false;

    float poolTime;

    public bool isInPool
    {
        get { return inPool; }
    }

    public virtual void Initialize() //Everytime it gets created
    {
        gameObject.SetActive(true);
        poolTime = autoPool;
        Unpool();
    }

    public virtual void Update()
    {
        if (isInPool) return;
        poolTime -= Time.deltaTime;
        if (poolTime <= 0)
            Pool();
    }

    public virtual void Unpool()
    {
        inPool = false;
    }

    public virtual void Pool()
    {
        inPool = true;
        gameObject.SetActive(false);
    }
}

