using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UIElements;

public class DmgPopUp : MonoBehaviour {
    private TextMeshPro text;
    public LeanTweenType easeType;

   
    private void Awake() {
        text = GetComponent<TextMeshPro>();
    }
    public void SetUp(float damage) {
        text.SetText(damage.ToString());
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 1).setDestroyOnComplete(true).setEase(easeType);
    }
}
