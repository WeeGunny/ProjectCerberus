﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbCam: MonoBehaviour
{

    public float sensitivity = 100f, smoothing = 1f;
    public Transform playerTransform;
    public static bool movePlayerCam = true;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movePlayerCam == true && !PauseMenu.GamePaused) {
            RotateCamera();
        }

        if (PauseMenu.GamePaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (!PauseMenu.GamePaused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void RotateCamera() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector2 lookInput = new Vector2(mouseX, mouseY);
        lookInput = Vector2.Scale(lookInput, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, lookInput.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, lookInput.y, 1f / smoothing);
        currentLookPos += smoothedVelocity;
        currentLookPos.y = Mathf.Clamp(currentLookPos.y, -90, 90);
        transform.localRotation = Quaternion.AngleAxis(-currentLookPos.y, Vector3.right);
        playerTransform.localRotation = Quaternion.AngleAxis(currentLookPos.x, playerTransform.up);

    }

    public static void ToggleCam() {
        if (Cursor.lockState == CursorLockMode.Locked) {
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Unlocked Cursor");
        }
        else {
            Cursor.lockState = CursorLockMode.Locked;
        }
        movePlayerCam = !movePlayerCam;
        Cursor.visible = !Cursor.visible;
        Debug.Log(Cursor.visible);
        GunManager.canFire = !GunManager.canFire;
    }
}
