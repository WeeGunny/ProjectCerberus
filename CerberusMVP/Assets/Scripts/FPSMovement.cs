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

    // Start is called before the first frame update
    private void Awake() {
        PlayerManager.instance.player = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        //This creates a physic shere at the ground check positon, radius of the sphere and layer it will interact with;
        isGrounded = Physics.CheckSphere(groundCheck.position, gcRadius, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Horizontal and Verticle refer to control stick movement not player movement
        //Therefore x = side to side  and z = Forward and Backward
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement *movementSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Goal") {
            LevelGenerator level = FindObjectOfType<LevelGenerator>();
            level.Win();
        }
    }
}
