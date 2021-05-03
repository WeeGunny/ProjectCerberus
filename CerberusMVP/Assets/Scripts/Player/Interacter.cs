using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public static Interacter instance;
    public static bool interacterExsists = false;
    public float InteractRange;
    public GameObject InteractUI;
    public static bool CanInteract;
    public bool IsInteracting;
    public static IInteractable interactableObject;
    // Start is called before the first frame update
    void Start()
    {
        if (!instance) {
            instance = this;
            interacterExsists = true;
        }
        else { Destroy(this); }
        if(!InteractUI) InteractUI = GameObject.Find("Interact UI");
    }

    // Update is called once per frame
    void Update()
    {
        if(!InteractUI) InteractUI = GameObject.Find("Interact UI");
        if(!IsInteracting) CanInteract = CheckForInteractable();

        if(!CanInteract && InteractUI.activeInHierarchy) HideInteractUI();
    }

    public bool CheckForInteractable() {
        Ray ray = rbCam.playerCam.ViewportPointToRay(new Vector3(.5f, .5f, 0),rbCam.playerCam.stereoActiveEye); // goes to center of screen;
        RaycastHit hit;
        Physics.Raycast(ray, out hit, InteractRange);
        if(hit.collider) {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if(interactable != null) {
                interactableObject = interactable;
                ShowInteractUI();
                Debug.Log("Can Interact with someone");
                return true;
            }
        }
        interactableObject = null;
        if(InteractUI.activeInHierarchy)HideInteractUI();
        return false;
    }

    public void HideInteractUI() {
        InteractUI.SetActive(false);

    }
    public void ShowInteractUI() {
        InteractUI.SetActive(true);

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        if(rbCam.playerCam)Gizmos.DrawLine(rbCam.playerCam.transform.position, rbCam.playerCam.ViewportPointToRay(new Vector3(.5f, .5f, 0)).GetPoint(InteractRange));
    }
}
