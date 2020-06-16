using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class GrapplingGun : MonoBehaviour {

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;

    [Header("Transform Objects")]
    public Transform gunTip;
    public Transform camera;
    public Transform player;

    [Header("Values")]
    public float maxDistance = 50f;
    public float reelInSpeed = 5f;
    public float maxSpeed = 12f;
    public float dismountTimer = 3f;
    private SpringJoint joint;

    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        Rigidbody rb = player.GetComponent<Rigidbody>();

        if (Input.GetKeyDown(KeyCode.Q)) {
            StartGrapple();
        }

        else if (Input.GetKeyUp(KeyCode.Q)) {
            StopGrapple();
        }

        if (IsGrappling()) {
            //Dismount grappling hook after reaching the grappling point
            float reachedPositionDistance = 1f;
            float yMultiplier = 3.5f;
            Vector3 direction = (grapplePoint - player.transform.position).normalized;
            rb.velocity += direction * Time.deltaTime * reelInSpeed * yMultiplier * Mathf.Abs(grapplePoint.y - player.transform.position.y);

            dismountTimer -= Time.deltaTime;
            if (dismountTimer <= 0)
            {
                StopGrapple();
                
            }

            if (Vector3.Distance(transform.position, grapplePoint) < reachedPositionDistance) {
                StopGrapple();
            }
        }
        Vector3.ClampMagnitude(rb.velocity, maxSpeed);




    }

    //Called after Update
    void LateUpdate() {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = 0;

            //Adjust these values to fit your game.
            joint.spring = 10f;
            joint.damper = 20f;
            joint.massScale = 1f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }


    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
        dismountTimer = 3f;
    }

    private Vector3 currentGrapplePosition;

    void DrawRope() {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling() {
        return joint != null;
    }

    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}
