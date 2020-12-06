﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbPlayer : MonoBehaviour {
    public Rigidbody rb;

    [Header ("Variables")]
    public float movementSpeed = 10f;
    public float jumpHeight = 100f;
    public bool isGrounded = true;
    private const int maxJump = 2;
    private int currentJump = 0;
    public Animator anim;
    public float rayDistance;
    public bool movePlayer = true;
    private Vector3 movementVector;
    private Vector3 movement;
    private PlayerStats stats;
    // Start is called before the first frame update
    void Start() {
        PlayerManager.playerExists = true;
        PlayerManager.instance.player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update() {
        Jump();
        Grit();
    }

    private void FixedUpdate() {
        if (movePlayer == true) {
            Move();
        }
        Move();
        FindObjectOfType<AudioManager>().Play("Footsteps");
    }

    private void Move() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");
        movementVector = new Vector3(inputX , 0, inputZ) * movementSpeed * Time.deltaTime;
        //rb.velocity = movementVector;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movementVector);
        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || maxJump > currentJump))
        {
            {
                rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
                isGrounded = false;
                currentJump++;
            }

            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        currentJump = 0;
    }

    void Grit() {

        if (Input.GetKeyDown(KeyCode.G) && PlayerManager.instance.stats.Grit > 0) {
            PlayerManager.instance.stats.GritActive = !PlayerManager.instance.stats.GritActive;
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            Debug.Log("Grit Toggled");

            FindObjectOfType<AudioManager>().Play("Grit");
        }
        if (PlayerManager.instance.stats.GritActive == true)
        {
            PlayerManager.instance.stats.Grit -= Time.deltaTime * 80;
        }

    }

    public void toggleMovement() {
        movePlayer = !movePlayer;
    }
}
