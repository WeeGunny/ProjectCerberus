using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UIElements;

public class DmgPopUp : MonoBehaviour {
    public TextMeshPro text;
    public LeanTweenType easeType;
    Transform camTransform;

    private void Awake() {
        camTransform = PlayerManager.instance.player.GetComponent<rbPlayer>().playerCam.transform;
    }
    public void SetUp(float damage) {
        text.SetText(damage.ToString());
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 1).setDestroyOnComplete(true).setEase(easeType);
        LeanTween.moveLocal(gameObject, new Vector3(0, -0.4f, 0), .5f).setEase(easeType); ;
    }

    private void FixedUpdate() {
        transform.LookAt(transform.position+camTransform.rotation * Vector3.forward,camTransform.rotation*Vector3.up);
    }
}
