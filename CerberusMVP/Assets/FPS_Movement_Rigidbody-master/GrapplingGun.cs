using UnityEngine;
using UnityEngine.Rendering;

public class GrapplingGun : MonoBehaviour {

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    public Rigidbody controller;
    public float maxDistance = 50f;
    private SpringJoint joint;

    public enum Status
    {
        idle,
        grappleFlying
    }
    public Status status;

    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            StartGrapple();
            GrapplePull();
        }
        else if (Input.GetKeyUp(KeyCode.Q)) {
            StopGrapple();
        }

        switch (status)
        {
            case Status.grappleFlying:
                GrapplePull();
                break;
        }
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
            joint.minDistance = distanceFromPoint * 0.25f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }

    public void GrapplePull()
    {
        Vector3 grappleDir = (currentGrapplePosition - transform.position).normalized;

        float grappleSpeedMin = 10f;
        float grappleSpeedMax = 40f;

        //Slows down the speed as the player gets closer to the hookshot position
        float grappleSpeed = Mathf.Clamp(Vector3.Distance(transform.position, currentGrapplePosition), grappleSpeedMin, grappleSpeedMax);
        float grappleSpeedMultiplier = 2f;

        controller.MovePosition(grappleDir * grappleSpeed * grappleSpeedMultiplier * Time.deltaTime);
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
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
