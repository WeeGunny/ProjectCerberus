using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float maxCamTilt, wallRunCamTilt;
    public Transform orientation;
    AudioManager audio;
    bool playingSound;


    // Start is called before the first frame update
    void Start() {
        PlayerManager.playerExists = true;
        PlayerManager.instance.player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        audio = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update() {
        Jump();
        Grit();
        CheckForWall();
        WallRunInput();
        CameraTilt();
    }

    private void CameraTilt() {
        playerCam.transform.localRotation = Quaternion.Euler(playerCam.transform.rotation.x, playerCam.transform.rotation.y, wallRunCamTilt);

        //gradually turns cam away from wall left or right;
        if (Math.Abs(wallRunCamTilt) < maxCamTilt && isWallRight && isWallRunning) {
            wallRunCamTilt += Time.deltaTime * maxCamTilt * 2;
        }
        if (Math.Abs(wallRunCamTilt) < maxCamTilt && isWallLeft && isWallRunning) {
            wallRunCamTilt -= Time.deltaTime * maxCamTilt * 2;
        }

        if (wallRunCamTilt > 0 && !isWallRunning) {
            wallRunCamTilt -= Time.deltaTime * maxCamTilt * 2;
        }
        if (wallRunCamTilt < 0 && !isWallRunning) {
            wallRunCamTilt += Time.deltaTime * maxCamTilt * 2;
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
        if (!playingSound && rb.velocity.magnitude>0) {
            playingSound = true;
            StartCoroutine(SoundDelays("Footsteps",1));
        }
    }
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
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
    private void WallRunInput() {
        if (rb.velocity.magnitude > 0 && !Grounded()) {
            if (Input.GetKey(KeyCode.D) && isWallRight) StartWallRun();
            if (Input.GetKey(KeyCode.A) && isWallLeft) StartWallRun();
        }
        else {
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
                StartCoroutine(SoundDelays("WallRun",1));
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

    void Grit() {

        if (Input.GetKeyDown(KeyCode.G) && PlayerManager.instance.stats.Grit > 0) {
            PlayerManager.instance.stats.GritActive = !PlayerManager.instance.stats.GritActive;
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            Debug.Log("Grit Toggled");
        }
        if (PlayerManager.instance.stats.GritActive == true) {
            PlayerManager.instance.stats.Grit -= Time.deltaTime * 80;
        }

    }

    IEnumerator SoundDelays(String soundClipName, float delayTime) {
        yield return new WaitForSeconds(delayTime);
        audio.Play(soundClipName);
        playingSound = false;
    }

    public void toggleMovement() {
        movePlayer = !movePlayer;
    }
}
