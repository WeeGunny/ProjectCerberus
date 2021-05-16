using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticleSystem : MonoBehaviour
{
    ParticleSystem ps;
    float lifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();   
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (!ps.IsAlive() || lifeTime >= 4)
        {
            Destroy(gameObject);
        }
    }
}
