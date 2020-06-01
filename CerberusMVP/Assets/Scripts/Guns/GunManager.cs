using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {
    public Gun[] guns = new Gun[9];
    public Camera fpsCam;
    Gun currentGun;
    GameObject currentGunObject;


    // Start is called before the first frame update
    void Start() {
        currentGunObject = Instantiate(guns[0].gunPrefab, transform);
        currentGun = currentGunObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update() {
        CheckForShooting();
        SwitchGun();


    }

    private void CheckForShooting() {
        if (Input.GetButtonDown("Fire1")) {
            if (currentGun.fireType == FireType.Semi || currentGun.fireType == FireType.Burst)
                currentGun.ManualFire();

            if (currentGun.fireType == FireType.Laser) {
                currentGun.LaserFire();
            }
        }

        if (Input.GetButton("Fire1")) {
            if (currentGun.fireType == FireType.Auto)
                currentGun.AutomaticFire();
            if (currentGun.fireType == FireType.Laser) {
                currentGun.UpdateLaser();
                currentGun.firingLaser = true;
            }
        }
        if (Input.GetButtonUp("Fire1")) {
            if (currentGun.fireType == FireType.Laser) {
                currentGun.firingLaser = false;
            }

        }

        if (Input.GetButtonDown("Fire2")) {
            if (PlayerManager.instance.stats.Moxie >= currentGun.moxieRequirement) {
                currentGun.AltFire();
            }
            else {
                Debug.Log("Not Enough moxie to fire");
            }
        }
    }

    void SwitchGun() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Destroy(currentGunObject);
            if (guns[0] != null) {
                currentGunObject = Instantiate(guns[0].gunPrefab, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Destroy(currentGunObject);
            if (guns[1] != null) {
                currentGunObject = Instantiate(guns[1].gunPrefab, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Destroy(currentGunObject);
            if (guns[2] != null) {
                currentGunObject = Instantiate(guns[2].gunPrefab, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            Destroy(currentGunObject);
            if (guns[3] != null) {
                currentGunObject = Instantiate(guns[3].gunPrefab, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            Destroy(currentGunObject);
            if (guns[4] != null) {
                currentGunObject = Instantiate(guns[4].gunPrefab, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            Destroy(currentGunObject);
            if (guns[5] != null) {
                currentGunObject = Instantiate(guns[5].gunPrefab, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            Destroy(currentGunObject);
            if (guns[6] != null) {
                currentGunObject = Instantiate(guns[6].gunPrefab, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            Destroy(currentGunObject);
            if (guns[7] != null) {
                currentGunObject = Instantiate(guns[7].gunPrefab, transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            Destroy(currentGunObject);
            if (guns[8] != null) {
                currentGunObject = Instantiate(guns[8].gunPrefab, transform);
            }
        }
        currentGun = currentGunObject.GetComponent<Gun>();
        PlayerManager.instance.stats.activeGun = currentGun;
    }
}
