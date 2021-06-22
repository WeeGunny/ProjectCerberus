using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElementGun : Gun {
    public GameObject chargeEffect;
    [SerializeField] List<GameObject> ElementalAmmo = new List<GameObject>();
    int currentElementIndex = 0;
    [SerializeField] float chargeTime;
    [SerializeField] ParticleSystem ps;
    public Vector3 chargeStartRBG, chargeFullRGB;
    ParticleSystem.MainModule chargeParticles;

    private void Start() {
        chargeParticles = ps.main;
        primaryAmmo = ElementalAmmo[0];
    }
    public override void OnPrimaryFire() {


    }


    protected override void Update() {
        if (fireHeld && allowHold && readyToShoot) {
            chargeTime += Time.deltaTime * 10;
            chargeTime = Mathf.Clamp(chargeTime, 0, 25);
            if (chargeTime >= 1) {
                chargeEffect.SetActive(true);
            }
            if (chargeTime == 25) {
                chargeParticles.startColor = new Color(chargeFullRGB.x, chargeFullRGB.y, chargeFullRGB.z);
            }
        }
        primaryAmmo = ElementalAmmo[currentElementIndex];
    }

    public override void AltFire() {
        if (animator) animator.SetTrigger("isAltFire");
        if (currentElementIndex + 1 < ElementalAmmo.Count) currentElementIndex += 1;
        else currentElementIndex = 0;

    }

    void ShootChargeFire(InputAction.CallbackContext context) {

        if (readyToShoot && !reloading && clipAmmo > 0 && GunManager.canFire) {

            if (chargeTime >= 1) {
                Dmg += chargeTime;
                PlayerStats.Instance.Moxie -= chargeTime;
                Fire();
                Dmg -= chargeTime;
                chargeParticles.startColor = new Color(chargeStartRBG.x, chargeStartRBG.y, chargeStartRBG.z);
                chargeEffect.SetActive(false);
            }
            else {
                bulletsShot = 0;
                Fire();
            }
        }
        else if (readyToShoot && !reloading && clipAmmo <= 0 && GunManager.canFire) {
            ReloadDelay();
        }
        chargeTime = 0;

    }

    protected override void OnEnable() {
        controls.Gameplay.PrimaryFire.performed += HeldFire;
        controls.Gameplay.PrimaryFire.canceled += HeldFire;
        controls.Gameplay.PrimaryFire.canceled += ShootChargeFire;
        controls.Gameplay.PrimaryFire.Enable();
    }

    protected override void OnDisable() {
        controls.Gameplay.PrimaryFire.performed -= HeldFire;
        controls.Gameplay.PrimaryFire.canceled -= HeldFire;
        controls.Gameplay.PrimaryFire.canceled -= ShootChargeFire;
        controls.Gameplay.PrimaryFire.Disable();
    }



}
