using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed =1;
    public float jumpHeight = 3;
    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float gcRadius = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    [Header("Grappling Hook")]
    [SerializeField] private Transform debugHitTransform;
    [SerializeField] private Transform hookshotTransform;

    public enum Status 
    { 
        idle,
        hookshotThrown,
        hookshotFlying,
        WallRun
        
    }
    public Status status;

    private Camera playerCamera;
    public Vector3 hookshotPosition;
    private Vector3 velocityMomentum;
    private float hookshotSize;
    //GRAPPLING HOOK END

    // Start is called before the first frame update
    private void Awake() {
        //PlayerManager.instance.player = this.gameObject;
        playerCamera = transform.Find("Player Camera").GetComponent<Camera>();
        //GRAPPLING HOOK
        status = Status.idle;
        hookshotTransform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       


        //GRAPPLING HOOK
        switch (status)
        {
            default:
            case Status.idle:
                CharacterMovement();
                HandleHookshotStart();
                break;

            case Status.hookshotThrown:
                CharacterMovement();
                HandleHookshotThrown();
                break;

            case Status.hookshotFlying:
                HandleHookshotMovement();
                break;
        }
    }

    private void CharacterMovement() {
        //This creates a physic shere at the ground check positon, radius of the sphere and layer it will interact with;
        isGrounded = Physics.CheckSphere(groundCheck.position, gcRadius, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        // Horizontal and Verticle refer to control stick movement not player movement
        //Therefore x = side to side  and z = Forward and Backward
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * movementSpeed * Time.deltaTime);

        if (TestInputJump() && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Apply gravity to velocity
        if(status != Status.WallRun)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        //Apply Momentum
        velocity += velocityMomentum;

        //Move Character Controller
        controller.Move(velocity * Time.deltaTime);


        //Dampen Momentum
        if (velocityMomentum.magnitude >= 0f) {
            float momentumDrag = 3f;
            velocityMomentum -= velocityMomentum * momentumDrag * Time.deltaTime;
            if (velocityMomentum.magnitude < .0f) {
                velocityMomentum = Vector3.zero;
            }
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Goal") {
            LevelGenerator level = FindObjectOfType<LevelGenerator>();
            level.Win();
        }
    }

    private void ResetGravityEffect ()
    {
        velocity.y = 0f;
    }

    /***************************** GRAPPLING HOOK ******************************/
    private void HandleHookshotStart()
    {
        if (HookShotInput())
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit))
            {
                debugHitTransform.position = raycastHit.point;
                hookshotPosition = raycastHit.point;
                hookshotSize = 0f;
                hookshotTransform.gameObject.SetActive(true);
                hookshotTransform.localScale = Vector3.zero;
                status = Status.hookshotThrown;
            }
        }
    }

    private void HandleHookshotThrown()
    {
        hookshotTransform.LookAt(hookshotPosition);

        float hookshotThrowSpeed = 80f;
        hookshotSize += hookshotThrowSpeed * Time.deltaTime;
        hookshotTransform.localScale = new Vector3(1, 1, hookshotSize);

        if (hookshotSize >= Vector3.Distance(transform.position, hookshotPosition))
        {
            status = Status.hookshotFlying;
        }
    }

    private void HandleHookshotMovement()
    {
        hookshotTransform.LookAt(hookshotPosition);

        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotSpeedMin = 10f;
        float hookshotSpeedMax = 40f;

        //Slows down the speed as the player gets closer to the hookshot position
        float hookshotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), hookshotSpeedMin, hookshotSpeedMax);
        float hookshotSpeedMultiplier = 2f;

        controller.Move(hookshotDir * hookshotSpeed * hookshotSpeedMultiplier * Time.deltaTime);

        //Fall after reaching hookshot position
        float reachedHookshotPositionDistance = 1f;
        if (Vector3.Distance(transform.position, hookshotPosition) < reachedHookshotPositionDistance)
        {
            StopHookshot();
        }

        if (HookShotInput())
        {
            //Cancel Grappling Hook
            StopHookshot();
        }
        
        if (TestInputJump())
        {
            //Cancel with Jump
            float momentumExtraSpeed = 7f;
            velocityMomentum = hookshotDir * hookshotSpeed * momentumExtraSpeed;

            float jumpSpeed = 3f;
            velocityMomentum += Vector3.up * jumpSpeed;
            StopHookshot();
        }
    }

    private void StopHookshot()
    {
        status = Status.idle;
        ResetGravityEffect();
        hookshotTransform.gameObject.SetActive(false);
    }

    private bool HookShotInput()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

    private bool TestInputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
