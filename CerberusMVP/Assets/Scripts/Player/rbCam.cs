using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class rbCam : MonoBehaviour {

    public static float sensitivity = 1f;
    private float smoothing = 5f;
    public Transform playerTransform;
    public static bool movePlayerCam = true;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookPos;
    public static Camera playerCam;
    public Volume volume;

    public float inputX, inputY;
    private void Awake() {
        if(!playerCam) playerCam = this.GetComponent<Camera>();
        else { Destroy(this); }
    }

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        if(movePlayerCam == true && !PauseMenu.GamePaused) {
            RotateCamera();
        }
        GritEffect();
    }
    private void OnCamera(InputValue value) {
        Vector2 inputVector = value.Get<Vector2>();
        inputX = inputVector.x;
        inputY = inputVector.y;
    }

    public void RotateCamera() {
        Vector2 lookInput = new Vector2(inputX, inputY);
        lookInput = Vector2.Scale(lookInput, new Vector2(sensitivity / 5, sensitivity / 5));
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, lookInput.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, lookInput.y, 1f / smoothing);
        currentLookPos += smoothedVelocity;
        currentLookPos.y = Mathf.Clamp(currentLookPos.y, -90, 90);
        transform.localRotation = Quaternion.AngleAxis(-currentLookPos.y, Vector3.right);
        playerTransform.localRotation = Quaternion.AngleAxis(currentLookPos.x, playerTransform.up);
    }

    public void GritEffect() {
        if(PlayerStats.GritActive && volume.weight < 1.0f) {
            volume.weight += Time.deltaTime * 2 / Time.timeScale;
        }

        if(!PlayerStats.GritActive && volume.weight > 0.0f) {
            volume.weight -= Time.deltaTime * 2 / Time.timeScale;
        }

    }

    //locks the camera and shows the mouse to interact with UI
    public static void LockCam() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        movePlayerCam = false;
        GunManager.canFire = false;
        Interacter.instance.IsInteracting = true;
    }

    //unlocks cam and hides mouse
    public static void UnlockCam() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        movePlayerCam = true;
        GunManager.canFire = true;
        Interacter.instance.IsInteracting = false;

    }
}
