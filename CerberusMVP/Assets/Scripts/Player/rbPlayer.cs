﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbPlayer : MonoBehaviour {
    Rigidbody rb;
    public float movementSpeed = 10f;
    public float jumpHeight = 100f;
    public float rayDistance;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
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
        }
    }

    private bool Grounded() {

        return Physics.Raycast(transform.position, Vector3.down, rayDistance, LayerMask.GetMask("Room"));
    }

    void Grit() {

        if (Input.GetKeyDown(KeyCode.G) && PlayerManager.instance.stats.Grit > 0) {
            PlayerManager.instance.stats.GritActive = !PlayerManager.instance.stats.GritActive;
            Time.timeScale = 0.2f;
            Debug.Log("Grit Toggled");
        }
        if (PlayerManager.instance.stats.GritActive == true) {
            PlayerManager.instance.stats.Grit -= Time.deltaTime * 80;
        }

    }
}
