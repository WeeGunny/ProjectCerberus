using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallrun : MonoBehaviour
{
    [Header("Properties")]
    public bool isWallRunning = false; //If the player is currently Wall Running
    public float wallRunDuration = 5; //How long you can wall run for before falling off
    public float upForce = 25f; //The vertical force applied when the player is Wall Running
    public float constantUpForce = 100f; //The Vertical force required to not have the player fall
    public bool isWallLeft;
    public bool isWallRight;

    [Header("Camera")]
    public float rayDistance;
    public float camAngle = 20;
    public float curCamAngle;
    public Transform cam;

    private Vector3 wallDir; //The wall's direction relative to the player

    [Header("Controller")]
    public FPSMovement movement;
    public Rigidbody rb;
    public static Wallrun instance;

    private bool isCancellingWallRunning;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
        wallDir = Vector3.up;
    }

    private void Update()
    {
        WallRunning();
        if(cam != null)
        {
            if(Physics.Raycast(transform.position, transform.right, rayDistance) && isWallRunning)
            {
                curCamAngle = camAngle;
                isWallRight = true;
                isWallLeft = false;
            }
            else if (Physics.Raycast(transform.position, -transform.right, rayDistance) && isWallRunning)
            {
                curCamAngle = -camAngle;
                isWallRight = false;
                isWallLeft = true;

            }
            else
            {
                curCamAngle = 0;
                isWallRight = false;
                isWallLeft = false;
            }
        }
    }

    public void EnterWallRunning()
    {
        if (!isWallRunning)
        {
            movement.status = FPSMovement.Status.WallRun;
        }

        isWallRunning = true;

    }

    private void WallRunning()
    {
        
 
    }

    private bool CheckSurfaceAngle (Vector3 v, float angle)
    {
        return Mathf.Abs(angle - Vector3.Angle(Vector3.up, v)) < 0.1f;
    }

    private void ExitWallRunning()
    {
        movement.status = FPSMovement.Status.idle;
    }

    private void OnCollisionStay(Collision other)
    {
        Vector3 surface = other.contacts[0].normal;
        if (CheckSurfaceAngle(surface, 90))
        {
            EnterWallRunning();
            wallDir = surface;

            isCancellingWallRunning = false;
            CancelInvoke("ExitWallRunning");
        }
        if (!isCancellingWallRunning)
        {
            isCancellingWallRunning = true;
            Invoke("ExitWallRunning", wallRunDuration * Time.deltaTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (isWallRunning)
        {
            ExitWallRunning();
        }
    }
}
