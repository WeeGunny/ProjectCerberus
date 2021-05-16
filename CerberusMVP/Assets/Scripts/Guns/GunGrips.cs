using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGrips : MonoBehaviour
{
    public Transform leftGrip, rightGrip;
    public Transform rightIndex, rightThumb, rightMiddle, rightRing, rightPinky;
    public Transform leftIndex, leftThumb, leftMiddle, leftRing, leftPinky;


    public void SetGripPosition(GunGrips gripToSet) {
        gripToSet.rightGrip.position = rightGrip.position;
        gripToSet.rightGrip.rotation = rightGrip.rotation;
        gripToSet.leftGrip.position = leftGrip.position;
        gripToSet.leftGrip.rotation = leftGrip.rotation;
    }

    public void setFingerPosition(GunGrips gripToSet) {
        //set right hand fingers
        gripToSet.rightThumb.position = rightThumb.position;
        gripToSet.rightIndex.position = rightIndex.position;
        gripToSet.rightMiddle.position = rightMiddle.position;
        gripToSet.rightRing.position = rightMiddle.position;
        gripToSet.rightPinky.position = rightPinky.position;
        //set left hand fingers
        gripToSet.leftThumb.position = leftThumb.position;
        gripToSet.leftIndex.position = leftIndex.position;
        gripToSet.leftMiddle.position = leftMiddle.position;
        gripToSet.leftRing.position = leftMiddle.position;
        gripToSet.leftPinky.position = leftPinky.position;
    }

}
