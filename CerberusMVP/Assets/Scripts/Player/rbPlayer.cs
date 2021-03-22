using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class rbPlayer : MonoBehaviour {
    public Rigidbody rb;
    public Camera playerCam;
    public float movementSpeed = 6f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 100f;
    public float rayDistance;
    public bool movePlayer = true;
    private Vector2 moveInput;
    private Vector3 movementVector;
    //Wall Run stuff
    public LayerMask isWall;
    public float maxWallRunSpeed, wallRunForce, maxWallRunTime;
    public bool isWallLeft, isWallRight;
    public bool isWallRunning = false;
    public bool doubleJump, isSprinting = false;
    public float maxCamTilt;
    float wallRunCamTilt;
    public Transform orientation;
    bool playingSound;
    public static bool isDead = false;
    public bool isGrounded;
    public Transform targetPoint;
    //Animator
    public Animator anim;


    //Controller
    PlayerControls controls;

    void Awake() {
        // We only want one PlayerManager at a time
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
        CameraTilt();
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

        //audio.pitch = Time.timeScale;
    }

    private void InputManager() {
        if (rb.velocity.magnitude > 0 && !Grounded()) {
            if (Input.GetKey(KeyCode.D) && isWallRight) StartWallRun();
            if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallRun();
        }
        else StopWallRun();
    }

    private void FixedUpdate() {
        Vector3 moveX = transform.right * moveInput.x;
        Vector3 moveZ = transform.forward * moveInput.y;
        if (!isSprinting) movementVector = (moveX + moveZ) * movementSpeed;
        if (isSprinting) movementVector = (moveX + moveZ) * sprintSpeed;
        if (PlayerStats.GritActive) movementVector = movementVector / Time.timeScale;
        rb.velocity = new Vector3(movementVector.x, rb.velocity.y, movementVector.z);

    }

    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    public void Sprint() {
        isSprinting = !isSprinting;
        anim.SetBool("isSprinting", isSprinting);
        FindObjectOfType<AudioManager>().Play("Running", gameObject);
    }

    private void OnJump() {
        if (Grounded()) {
            Debug.Log("Grounded");
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            AudioManager.audioManager.Play("Jump", gameObject); // if AudioManager does not exist, things after this line will _not_ run

        }
        else if (doubleJump) {
            doubleJump = false;
            rb.velocity.Set(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector2.up * (jumpHeight), ForceMode.Impulse);
            doubleJump = false;
            AudioManager.audioManager.Play("Jump", gameObject);

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
        PlayerStats ps = PlayerManager.stats;
        if (PlayerStats.moxieBatteries > 0 && PlayerStats.Moxie < ps.moxieMax) {
            PlayerStats.moxieBatteries -= 1;
            PlayerStats.Moxie += 50;
            Mathf.Clamp(PlayerStats.Moxie, 0, ps.moxieMax);
            Debug.Log("Using moxie Battery" + ps.moxieMax);
            FindObjectOfType<AudioManager>().Play("Moxie Battery", gameObject);
        }
        else if (PlayerStats.moxieBatteries <= 0) {
            Debug.Log("You have no moxie Batteries");
        }
        else if (PlayerStats.Moxie >= ps.moxieMax) {
            Debug.Log("Your Moxie is Already full");
        }

    }

    private void OnHealthPack() {
        PlayerStats ps = PlayerManager.stats;
        if (PlayerStats.HealthPacks > 0 && PlayerStats.Health < ps.maxHeath) {
            PlayerStats.HealthPacks -= 1;
            PlayerStats.Health += 50;
            Mathf.Clamp(PlayerStats.Health, 0, ps.maxHeath);
            FindObjectOfType<AudioManager>().Play("Health Pack", gameObject);
        }

    }

    public bool Grounded() {
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, LayerMask.GetMask("Room"));
    }
    public void CheckForWall() {
        isWallRight = Physics.Raycast(transform.position, orientation.right, 1f, isWall);
        isWallLeft = Physics.Raycast(transform.position, -orientation.right, 1f, isWall);
        if (!isWallRight && !isWallLeft) {
            StopWallRun();
        }
    }

    private void StartWallRun() {
        rb.useGravity = false;
        isWallRunning = true;
        if (rb.velocity.magnitude < maxWallRunSpeed) {
            rb.AddForce(orientation.forward * wallRunForce * Time.deltaTime);
            //keeps player on wall by adding force in direction of wall.
            if (isWallRight) {
                rb.AddForce(orientation.right * wallRunForce / 5 * Time.deltaTime);
                if (!playingSound && rb.velocity.magnitude > 1) {
                    playingSound = true;
                }
            }
            else {
                rb.AddForce(-orientation.right * wallRunForce / 5 * Time.deltaTime);
            }
        }
    }

    private void StopWallRun() {
        rb.useGravity = true;
        isWallRunning = false;
        anim.SetBool("isWallRunningRight", false);
        anim.SetBool("isWallRunningLeft", false);
    }

    private void CameraTilt() {
        //gradually turns cam away from wall left or right;
        if (Math.Abs(wallRunCamTilt) < maxCamTilt && isWallRight && isWallRunning) wallRunCamTilt += Time.deltaTime * maxCamTilt * 2;
        if (Math.Abs(wallRunCamTilt) < maxCamTilt && isWallLeft && isWallRunning) wallRunCamTilt -= Time.deltaTime * maxCamTilt * 2;
        if (wallRunCamTilt > 0 && !isWallRunning) wallRunCamTilt -= Time.deltaTime * maxCamTilt * 2;
        if (wallRunCamTilt < 0 && !isWallRunning) wallRunCamTilt += Time.deltaTime * maxCamTilt * 2;
        if (wallRunCamTilt != 0) playerCam.transform.localRotation = Quaternion.Euler(playerCam.transform.rotation.x, playerCam.transform.rotation.y, wallRunCamTilt);
    }

    private void OnGrit() {
        if (PlayerStats.Grit > 0 && PlayerStats.GritActive == false && !PauseMenu.GamePaused) {
            PlayerStats.GritActive = true;
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else if (PlayerStats.GritActive == true) {
            PlayerStats.GritActive = false;
            Time.timeScale = 1f;


        }

    }

    public void PlayStepSound() {
        if(rb.velocity.magnitude>0.5f && Grounded())AudioManager.audioManager.Play("Walking",gameObject);
    }

    public void toggleMovement() {
        movePlayer = !movePlayer;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - rayDistance, transform.position.z));
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
