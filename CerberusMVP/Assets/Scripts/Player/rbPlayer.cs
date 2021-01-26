using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class rbPlayer : MonoBehaviour {
    public Rigidbody rb;
    public Camera playerCam;
    public float movementSpeed = 6f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 100f;
    public float rayDistance;
    public bool movePlayer = true;
    private Vector3 movementVector;
    //Wall Run stuff
    public LayerMask isWall;
    public float maxWallRunSpeed, wallRunForce, maxWallRunTime;
    public bool isWallLeft, isWallRight;
    bool isWallRunning, doubleJump;
    public float maxCamTilt;
    float wallRunCamTilt;
    public Transform orientation;
    AudioManager audioManager;
    bool playingSound;
    public static bool isDead = false;
    public bool isGrounded;

    //Grit Effect
    public Volume volume;

    //Animator
    public Animator anim;

    void Awake() {
        PlayerManager.playerExists = true;
        if (PlayerManager.player == null) {
            PlayerManager.player = this.gameObject;
            //DontDestroyOnLoad(gameObject);
        }
        //else {
        //    Destroy(gameObject);
        //}
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
        isDead = false;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        Grit();
        CheckForWall();
        CameraTilt();
        InputManager();
        isGrounded = Grounded();
        if (Grounded()) doubleJump = true;


        if (isDead)
        {
            SceneManager.LoadScene("DeathScene");

        }

        if (rb.velocity.magnitude >1 && Grounded())
        {
            anim.SetBool("isWalking", true);
        }

        if (rb.velocity.magnitude <1 && Grounded())
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void InputManager() {
        if (Input.GetKeyDown(KeyCode.V)) MoxieBattery();
        if (Input.GetKeyDown(KeyCode.C)) HealthPack();
        if (Input.GetKeyDown(KeyCode.G) && PlayerStats.Grit > 0) {
            PlayerManager.stats.GritActive = !PlayerManager.stats.GritActive;
            FindObjectOfType<AudioManager>().Play("Grit Activated",gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (rb.velocity.magnitude > 0 && !Grounded()) {
            if (Input.GetKey(KeyCode.D) && isWallRight) StartWallRun();
            if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallRun();
        }
        else StopWallRun();

        if (Input.GetKeyDown(KeyCode.LeftShift) && Grounded() && rb.velocity.magnitude > 1)
        {
            anim.SetBool("isSprinting", true);
            movementSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || rb.velocity.magnitude < 1)
        {
            anim.SetBool("isSprinting", false);
            movementSpeed = 6f;
        }
    }


    private void FixedUpdate() {
        if (movePlayer == true) {
            Move();
        }
    }

    private void Move() {
        Vector3 inputX = transform.right * Input.GetAxis("Horizontal");
        Vector3 inputZ = transform.forward * Input.GetAxis("Vertical");
        movementVector = (inputX + inputZ) * movementSpeed;
        rb.velocity = new Vector3(movementVector.x, rb.velocity.y, movementVector.z);
        if (!playingSound && rb.velocity.magnitude > 1) {
            playingSound = true;
            StartCoroutine(SoundDelays("Footsteps", 1));
        }
    }

    private void Jump() {
        if (Grounded()) {
            Debug.Log("Grounded");
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            anim.SetTrigger("isJumping");
            FindObjectOfType<AudioManager>().Play("Jump",gameObject);

        }
        else if (doubleJump) {
            rb.velocity.Set(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector2.up * (jumpHeight), ForceMode.Impulse);
            FindObjectOfType<AudioManager>().Play("Jump",gameObject);
            doubleJump = false;
            anim.SetTrigger("isDoubleJumping");
        }

        if (isWallRunning) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            if (isWallLeft)
            {
                rb.AddForce(orientation.right * jumpHeight * .5f, ForceMode.Impulse);
                anim.SetBool("isWallRunningLeft", true);
            }
            if (isWallRight)
            {
                rb.AddForce(-orientation.right * jumpHeight * .5f, ForceMode.Impulse);
                anim.SetBool("isWallRunningRight", true);
            }
            StopWallRun();
        }
    }

    private void MoxieBattery() {
        PlayerStats ps = PlayerManager.stats;
        if (PlayerStats.moxieBatteries > 0 && PlayerStats.Moxie < ps.moxieMax) {
            PlayerStats.moxieBatteries -= 1;
            PlayerStats.Moxie += 50;
            Mathf.Clamp(PlayerStats.Moxie, 0, ps.moxieMax);
            Debug.Log("Using moxie Battery" + ps.moxieMax);
            FindObjectOfType<AudioManager>().Play("Moxie Battery",gameObject);
        }
        else if(PlayerStats.moxieBatteries <= 0) {
            Debug.Log("You have no moxie Batteries");
        }
        else if (PlayerStats.Moxie >= ps.moxieMax) {
            Debug.Log("Your Moxie is Already full");
        }

    }

    private void HealthPack() {
        PlayerStats ps = PlayerManager.stats;
        if (PlayerStats.HealthPacks > 0 && PlayerStats.Health < ps.maxHeath) {
            PlayerStats.HealthPacks -= 1;
            PlayerStats.Health += 50;
            Mathf.Clamp(PlayerStats.Health, 0, ps.maxHeath);
            FindObjectOfType<AudioManager>().Play("Health Pack",gameObject);
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
                    StartCoroutine(SoundDelays("Footsteps", 1));
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

    void Grit() {
        if (PlayerManager.stats.GritActive && !PauseMenu.GamePaused) {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            if (volume.weight < 1.0f) {
                volume.weight += Time.deltaTime * 2;
                Debug.Log(volume.weight);
            }
        }
        else if (!PauseMenu.GamePaused) {
            Time.timeScale = 1f;
            if (volume.weight > 0.0f) {
                volume.weight -= Time.deltaTime * 2;
            }
        }
        if (PlayerManager.stats.GritActive == true) {
            PlayerStats.Grit -= Time.deltaTime * 40;
            FindObjectOfType<AudioManager>().Play("Grit Deactivated",gameObject);

        }
    }

    IEnumerator SoundDelays(String soundClipName, float delayTime) {
        yield return new WaitForSeconds(delayTime);
        audioManager.Play(soundClipName,gameObject);
        playingSound = false;
    }

    public void toggleMovement() {
        movePlayer = !movePlayer;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - rayDistance, transform.position.z));
    }

    void OnDestroy() {
        PlayerManager.player = null;
        PlayerManager.playerExists = false;
    }
}
