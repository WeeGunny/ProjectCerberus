using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class rbPlayer : MonoBehaviour {
    public Rigidbody rb;
    public Camera playerCam;
    public float movementSpeed = 10f;
    public float jumpHeight = 100f;
    public float rayDistance;
    public bool movePlayer = true;
    private Vector3 movementVector;
    //Wall Run stuff
    public LayerMask isWall;
    public float maxWallRunSpeed, wallRunForce, maxWallRunTime;
    public bool isWallLeft, isWallRight;
    [SerializeField]
    bool isWallRunning;
    public float maxCamTilt;
    float wallRunCamTilt;
    public Transform orientation;
    AudioManager audioManager;
    bool playingSound;

    //Grit Effect
    public Volume volume;

    // Start is called before the first frame update
    void Start() {
        PlayerManager.playerExists = true;
        PlayerManager.player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update() {
        Grit();
        CheckForWall();
        CameraTilt();
        InputManager();
    }
    private void InputManager() {
        if (Input.GetKeyDown(KeyCode.V)) MoxieBattery();
        if (Input.GetKeyDown(KeyCode.C)) HealthPack();
        if (Input.GetKeyDown(KeyCode.G) && PlayerManager.instance.stats.Grit > 0) PlayerManager.instance.stats.GritActive = !PlayerManager.instance.stats.GritActive;
        if (Input.GetKeyDown(KeyCode.Space)) Jump();

        if (rb.velocity.magnitude > 0 && !Grounded()) {
            if (Input.GetKey(KeyCode.D) && isWallRight) StartWallRun();
            if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallRun();
        }
        else StopWallRun();
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
        if (!playingSound && rb.velocity.magnitude > 0) {
            playingSound = true;
            StartCoroutine(SoundDelays("Footsteps", 1));
        }
    }

    private void Jump() {
        if (Grounded()) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        if (isWallRunning) {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
            if (isWallLeft) rb.AddForce(orientation.right * jumpHeight * .5f, ForceMode.Impulse);
            if (isWallRight) rb.AddForce(-orientation.right * jumpHeight * .5f, ForceMode.Impulse);
            StopWallRun();
        }
    }

    private void MoxieBattery() {
        PlayerStats ps = PlayerManager.instance.stats;
        if (ps.moxieBatteries>0 && ps.Moxie<ps.moxieMax) {
            ps.moxieBatteries -= 1;
            ps.Moxie += 50;
            Mathf.Clamp(ps.Moxie,0,ps.moxieMax);
        }
    }

    private void HealthPack() {
        PlayerStats ps = PlayerManager.instance.stats;
        if (ps.HealthPacks>0 && ps.Health<ps.maxHeath) {
            ps.HealthPacks -= 1;
            ps.Health += 50;
            Mathf.Clamp(ps.Health,0,ps.maxHeath);
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
                StartCoroutine(SoundDelays("WallRun", 1));
            }
            else {
                rb.AddForce(-orientation.right * wallRunForce / 5 * Time.deltaTime);
            }
        }
    }

    private void StopWallRun() {
        rb.useGravity = true;
        isWallRunning = false;
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
        if (PlayerManager.instance.stats.GritActive) {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            if (volume.weight < 1.0f) {
                volume.weight += Time.deltaTime * 2;
                Debug.Log(volume.weight);
            }
        }
        else {
            Time.timeScale = 1f;
            if (volume.weight > 0.0f) {
                volume.weight -= Time.deltaTime * 2;
            }
        }
        if (stats.GritActive == true) {
            stats.Grit -= Time.deltaTime * 40;
        }
    }

    IEnumerator SoundDelays(String soundClipName, float delayTime) {
        yield return new WaitForSeconds(delayTime);
        audioManager.Play(soundClipName);
        playingSound = false;
    }

    public void toggleMovement() {
        movePlayer = !movePlayer;
    }
}
