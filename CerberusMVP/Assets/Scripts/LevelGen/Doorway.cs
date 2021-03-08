using UnityEngine;

public class Doorway : MonoBehaviour
{
    public bool isExterior = false;
    [SerializeField]Material lockedDoor, exteriorDoor;


    public void SetOutdoor() {
        isExterior = true;
        gameObject.GetComponent<MeshRenderer>().material = exteriorDoor;
        gameObject.SetActive(true);
    }

    public void LockDoor() {
        gameObject.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().material = lockedDoor;
    }

    public void UnlockDoor() {
        gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().material = exteriorDoor;

    }
    // Show object's Normal as a red line
    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.rotation * Vector3.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);

    }
}
