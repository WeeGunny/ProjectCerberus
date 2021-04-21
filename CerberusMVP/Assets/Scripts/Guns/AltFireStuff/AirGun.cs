using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AirGun : Gun {
    public float altRange;
    public GameObject platformPrefab;
    GameObject aimBeamObject;
    LineRenderer aimLine;
    bool altHeld = false;

    private void Update() {

        if (altHeld) AltAimBeam();

    }
    public override void AltFire() {
        base.AltFire();
        altHeld = true;
        aimBeamObject = Instantiate(altAmmo);
        aimLine = aimBeamObject.GetComponent<LineRenderer>();
        aimLine.SetPosition(0,firePoint.position);

    }

    private void AltAimBeam() {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, altRange)) {
            aimLine.SetPosition(1, hit.point);
        }
        else {
            aimLine.SetPosition(1, ray.GetPoint(altRange));
        }
    }

    private void OnAltFireRealeased(InputAction.CallbackContext context) {
        altHeld = false;
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, altRange)) {
            aimLine.SetPosition(1, hit.point);
        }
        else {
            aimLine.SetPosition(1, ray.GetPoint(altRange));
        }
        Destroy(aimBeamObject);
        
    }

    protected override void OnEnable() {
        base.OnEnable();
        controls.Gameplay.AlternateFire.canceled += OnAltFireRealeased;
        controls.Gameplay.AlternateFire.Enable();
    }

    protected override void OnDisable() {
        base.OnDisable();
        controls.Gameplay.AlternateFire.canceled -= OnAltFireRealeased;
        controls.Gameplay.AlternateFire.Disable();

    }
}
