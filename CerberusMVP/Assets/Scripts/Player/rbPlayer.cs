using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

public class rbPlayer : MonoBehaviour {
    public Rigidbody rb;
    public Camera playerCam;
    public float movementSpeed = 6f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 100f;
    public float groundRayDistance;
    public float GritGravity;
    public bool movePlayer = true;
    private Vector2 moveInput;
    private Vector3 movementVector;
    //Wall Run stuff
    public LayerMask isWall;
    public float maxWallRunSpeed, wallRunForce, maxWallRunTime;
    public bool isWallLeft, isWallRight;
    public bool isWallRunning = false, doubleJump, isSprinting = false;
    public float maxCamTilt;
    [SerializeField] float wallRunCamTilt;
    public Transform orientation;
    bool playingSound;
    public static bool isDead = false;
    public bool isGrounded, hasBossKey;
    public Transform targetPoint;
    public StatsSO stats;

    //Animator
    public Animator anim;


    //Controller
    PlayerControls controls;

    void Awake() {
        PlayerManager.playerExists = true;
        controls = new PlayerControls();
        if (PlayerManager.player == null) {
            PlayerManager.player = this.gameObject;
        }
        else {
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody>();
        isDead = false;
    }

    // Update is called once per frame
    void Update() {
        CheckForWall();
        InputManager();
        isGrounded = Grounded();
        if (Grounded()) doubleJump = true;

        if (isDead) {
            SceneManager.LoadScene("DeathScene");
        }

        if (rb.velocity.magnitude > 1 && Grounded()) {
            anim.SetBool("isWalking", true);
        }

        if (rb.velocity.magnitude < 1 && Grounded()) {
            anim.SetBool("isWalking", false);
        }
    }

    private void InputManager() {
        if (rb.velocity.magnitude > 0 && !Grounded()) {
            if (isSprinting && isWallRight) StartWallRun();
            if (isSprinting && isWallLeft) StartWallRun();
        }
    }

    private void FixedUpdate() {
        if (movePlayer) {
            Vector3 moveX = transform.right * moveInput.x;
            Vector3 moveZ = transform.forward * moveInput.y;
            if (!isSprinting) movementVector = (moveX + moveZ) * movementSpeed;
            if (isSprinting) movementVector = (moveX + moveZ) * sprintSpeed;
            if (stats.GritActive) {
                movementVector = movementVector / Time.timeScale;
                rb.velocity += new Vector3(0, -19.62f, 0) * Time.fixedDeltaTime / Time.timeScale;
            }
            rb.velocity = new Vector3(movementVector.x, rb.velocity.y, movementVector.z);
        }
    }
    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }
    public void Sprint() {
        isSprinting = !isSprinting;
        anim.SetBool("isSprinting", isSprinting);
        //FindObjectOfType<AudioManager>().Play("Running", gameObject);
    }

    private void OnJump() {
        if (Grounded()) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            AudioManager.audioManager.Play("Jump", gameObject);

        }
        else if (doubleJump) {
            rb.velocity.Set(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector2.up * (jumpHeight), ForceMode.Impulse);
            AudioManager.audioManager.Play("Jump", gameObject);
            doubleJump = false;
        }

        if (isWallRunning) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            if (isWallLeft) {
                rb.AddForce(orientation.right * jumpHeight * .5f, ForceMode.Impulse);
                anim.SetBool("isWallRunningLeft", true);
            }
            if (isWallRight) {
                rb.AddForce(-orientation.right * jumpHeight * .5f, ForceMode.Impulse);
                anim.SetBool("isWallRunningRight", true);
            }
            StopWallRun();
        }
    }

    private void OnMoxieBattery() {

        if (stats.moxieBatteries > 0 && stats.Moxie < stats.moxieMax) {
            stats.moxieBatteries -= 1;
            stats.Moxie += 50;
            Mathf.Clamp(stats.Moxie, 0, stats.moxieMax);
            Debug.Log("Using moxie Battery" + stats.moxieMax);
            AudioManager.audioManager.Play("Moxie Battery", gameObject);
        }
        else if (stats.moxieBatteries <= 0) {
            Debug.Log("You have no moxie Batteries");
        }
        else if (stats.Moxie >= stats.moxieMax) {
            Debug.Log("Your Moxie is Already full");
        }
    }

    private void OnHealthPack() {
        if (stats.HealthPacks > 0 && stats.Health < stats.maxHeath) {
            stats.HealthPacks -= 1;
            stats.Health += 50;
            Mathf.Clamp(stats.Health, 0, stats.maxHeath);
            FindObjectOfType<AudioManager>().Play("Health Pack", gameObject);
        }
    }

    public bool Grounded() {
        return Physics.Raycast(transform.position, Vector3.down, groundRayDistance, LayerMask.GetMask("Room"));
    }
    public void CheckForWall() {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, isWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, isWall);
        if (!isWallRight && !isWallLeft && isWallRunning) {
            StopWallRun();
        }
    }


    private void StartWallRun() {
        rb.useGravity = false;
        isWallRunning = true;
        if (rb.velocity.magnitude < maxWallRunSpeed) {
            rb.AddForce(orientation.forward * wallRunForce * Time.deltaTime);
            //keestats player on wall by adding force in direction of wall.
            if (isWallRight) {
                rb.AddForce(orientation.right * wallRunForce / 5 * Time.deltaTime);
                LeanTween.rotateLocal(playerCam.gameObject, new Vector3(playerCam.transform.localRotation.x, playerCam.transform.localRotation.y, maxCamTilt), 0.5f);
            }
            else if (isWallLeft) {
                rb.AddForce(-orientation.right * wallRunForce / 5 * Time.deltaTime);
                LeanTween.rotateLocal(playerCam.gameObject, new Vector3(playerCam.transform.localRotation.x, playerCam.transform.localRotation.y, -maxCamTilt), 0.5f);
            }
        }
    }

    private void StopWallRun() {
        rb.useGravity = true;
        isWallRunning = false;
        anim.SetBool("isWallRunningRight", false);
        anim.SetBool("isWallRunningLeft", false);
        LeanTween.rotateLocal(playerCam.gameObject, new Vector3(playerCam.transform.localRotation.x, playerCam.transform.localRotation.y, 0), 0.5f);
    }

    private void OnGrit() {
        if (stats.Grit > 0 && stats.GritActive == false && !PauseMenu.GamePaused) {
            stats.GritActive = true;
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            rb.useGravity = false;

        }
        else if (stats.GritActive == true) {
            stats.GritActive = false;
            Time.timeScale = 1f;
            rb.useGravity = true;

        }
    }
    private void OnInteract() {
        if (Interacter.CanInteract) {
            if (Interacter.interactableObject != null) Interacter.interactableObject.Interact();
        }
    }

    public void PlayStepSound() {
        if (rb.velocity.magnitude > 0.5f && Grounded()) AudioManager.audioManager.Play("Walking", gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundRayDistance, transform.position.z));
    }

    private void OnEnable() {
        controls.Gameplay.Sprint.performed += ctx => Sprint();
        controls.Gameplay.Sprint.canceled += ctx => Sprint();
        controls.Gameplay.Sprint.Enable();

    }
    private void OnDisable() {
        PlayerManager.player = null;
        PlayerManager.playerExists = false;
        controls.Gameplay.Sprint.performed -= ctx => Sprint();
        controls.Gameplay.Sprint.canceled -= ctx => Sprint();
        controls.Gameplay.Sprint.Disable();
    }
}
