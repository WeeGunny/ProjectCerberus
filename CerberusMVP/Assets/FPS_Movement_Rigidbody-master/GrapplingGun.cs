using UnityEngine;
using UnityEngine.Rendering;

public class GrapplingGun : MonoBehaviour {

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;

    [Header ("Transform Objects")]
    public Transform gunTip; 
    public Transform camera;
    public Transform player;
    
    [Header("Values")]
    public float maxDistance = 50f;
    public float cooldownTime = 5;
    public float nextFireTime = 5;
    public bool justOnce;
    private SpringJoint joint;

    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartGrapple();
                nextFireTime = Time.time + cooldownTime;
                justOnce = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            StopGrapple();
        }

        if (Time.time > nextFireTime && justOnce == false)
        {
            justOnce = true;
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
            joint.spring = 10f;
            joint.damper = 0f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }

        //Dismount grappling hook after reaching the grappling point
        float reachedPositionDistance = 1f;
        if (Vector3.Distance(transform.position, grapplePoint) < reachedPositionDistance)
        {
            StopGrapple();
        }
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
