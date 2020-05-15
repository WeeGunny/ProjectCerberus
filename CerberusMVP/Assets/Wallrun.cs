using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Wallrun : MonoBehaviour {
    [Header("Properties")]
    public bool isWallRunning = false; //If the player is currently Wall Running
    public float wallRunDuration = 5; //How long you can wall run for before falling off
    float wallRunCountdown;
    public bool isWallLeft;
    public bool isWallRight;
    public static Wallrun wallrun;

    [Header("Camera")]
    public float rayDistance;
    public Transform cam;

    [Header("Controller")]
    public FPSMovement movement;

    private void Start() {
        wallrun = this;
    }

    private void Update() {
        if (cam != null) {
            if (Physics.Raycast(transform.position, transform.right, rayDistance)) {

                isWallRight = true;
                isWallLeft = false;

            }
            else if (Physics.Raycast(transform.position, -transform.right, rayDistance)) {
                isWallRight = false;
                isWallLeft = true;

            }
            else {
                isWallRight = false;
                isWallLeft = false;
            }
            if (movement.isGrounded == false && isWallLeft == true|| movement.isGrounded == false && isWallRight == true) {
                if (isWallRunning == false) {
                    EnterWallRunning();
                }

            }

            if (isWallRunning) {
                wallRunCountdown -= Time.deltaTime;
                wallRunCountdown = Mathf.Clamp(wallRunCountdown, 0, wallRunDuration);
                Debug.Log(wallRunCountdown.ToString("F2"));

                if(!isWallLeft && !isWallRight) {
                    ExitWallRunning();
                }

                if (wallRunCountdown == 0) {
                    ExitWallRunning();
                }
            }

        }
    }

    public void EnterWallRunning() {
        movement.status = FPSMovement.Status.WallRun;
        movement.velocity.y = 0;
        isWallRunning = true;
        wallRunCountdown = wallRunDuration;
        if (isWallLeft)
            cam.rotation = Quaternion.Euler(cam.rotation.x, cam.rotation.y, -30);
        if (isWallRight)
           cam.rotation = Quaternion.Euler(cam.rotation.x, cam.rotation.y, 30);

        Debug.Log("Entered WallRun");
       



    }

    public void ExitWallRunning() {

        movement.status = FPSMovement.Status.idle;
        isWallRunning = false;
        cam.rotation = Quaternion.Euler(cam.rotation.x, cam.rotation.y, 0);
        
        Debug.Log("Ending WallRun");
    }
}
