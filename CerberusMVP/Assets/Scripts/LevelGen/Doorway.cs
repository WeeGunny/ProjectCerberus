using UnityEngine;

public class Doorway : MonoBehaviour
{
    public bool isOutdoor;
    // Show object's Normal as a red line
    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.rotation * Vector3.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);

    }
}
