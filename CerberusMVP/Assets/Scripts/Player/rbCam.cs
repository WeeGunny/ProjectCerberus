using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbCam : MonoBehaviour {

    public float sensitivity = 100f, smoothing = 1f;
    public Transform playerTransform;
    public static bool movePlayerCam = true;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookPos;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update() {
        if (movePlayerCam == true && !PauseMenu.GamePaused) {
            RotateCamera();
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

    //locks the camera and shows the mouse to interact with UI
    public static void LockCam() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        movePlayerCam = false;
        GunManager.canFire = false;
    }

    //unlocks cam and hides mouse
    public static void UnlockCam() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        movePlayerCam = true;
        GunManager.canFire = true;

    }
}
