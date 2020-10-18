using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbPlayer : MonoBehaviour {
    public Rigidbody rb;

    [Header ("Variables")]
    public float movementSpeed = 10f;
    public float jumpHeight = 100f;
    public int MaxDoubleJumps = 1;
    public int DoubleJumpCounter = 0;

    public float rayDistance;
    private Vector3 movement;
    private PlayerStats stats;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update() {

        Jump();
        Grit();


    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        movement = new Vector3(inputX, 0, inputZ) * movementSpeed * Time.fixedDeltaTime;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPosition);

    }
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Grounded())
                rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            DoubleJumpCounter = 0;

            //If in mid air after a jump, allow another jump
            if(!Grounded() && DoubleJumpCounter < MaxDoubleJumps)
                rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            DoubleJumpCounter++;
        }
    }

    public bool Grounded() {

        return Physics.Raycast(transform.position, Vector3.down, rayDistance, LayerMask.GetMask("Room"));
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
}
