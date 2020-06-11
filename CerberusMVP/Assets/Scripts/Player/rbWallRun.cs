using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbWallRun : MonoBehaviour {

    public float rayDistance;
    public float wallRunUpForce;
    public Transform cam;
    rbPlayer player;
    Rigidbody rb;

    private void Start() {
        player = GetComponent<rbPlayer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        rbCam.movePlayerCam = true;
        if (isWallRunning()) {
            rb.AddRelativeForce(Vector3.up * wallRunUpForce, ForceMode.Impulse);
            if (isWallLeft())
                cam.localEulerAngles = new Vector3(cam.rotation.x, cam.rotation.y, -30f);
            if (isWallRight())
                cam.localEulerAngles = new Vector3(cam.rotation.x, cam.rotation.y, 30f);
            rbCam.movePlayerCam = false;
        }
    }

    bool isWallLeft() {
        return Physics.Raycast(transform.position, -transform.right, rayDistance, LayerMask.GetMask("Room"));
    }

    bool isWallRight() {
        return Physics.Raycast(transform.position, transform.right, rayDistance, LayerMask.GetMask("Room"));
    }
    public bool isWallRunning() {
        player = GetComponent<rbPlayer>();
        if (!player.Grounded()) {
            if (isWallLeft() || isWallRight()) {
                if (isMoving()) {
                    Debug.Log("WallRun Running");
                    return true;
                }
            }
        }
        return false;
    }
    bool isMoving() {
        float inputZ = Input.GetAxis("Vertical");
        if (inputZ > 0.1f) {
            return true;
        }
        return false;
    }
}
