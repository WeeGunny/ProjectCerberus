using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject firePoint;
    public GameObject spawnedLaser;
    // Start is called before the first frame update
    void Start()
    {
        spawnedLaser = Instantiate(laserPrefab, firePoint.transform) as GameObject;
        spawnedLaser.GetComponent<LineRenderer>().useWorldSpace= false;
        spawnedLaser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            FireLaser();
        }
        if (Input.GetMouseButton(0)) {
            UpdateLaser();
        }
        if (Input.GetMouseButtonUp(0)) {
            StopLaser();
        }
    }

   public void FireLaser() {
        spawnedLaser.SetActive(true);
    }

    public void UpdateLaser() {
        if(firePoint != null) {
            spawnedLaser.transform.position = firePoint.transform.position;
        }
    }

    public void StopLaser() {
        spawnedLaser.SetActive(false);
    }
}
