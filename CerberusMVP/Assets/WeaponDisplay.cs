using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour {
    public CanvasGroup canvasGroup => gameObject.GetComponent<CanvasGroup>();
    public float fadeTime = 0.5f;
    // Start is called before the first frame update
    void Start() {

        
    }


    public void FadeOut() {

        LeanTween.alphaCanvas(canvasGroup, 0, fadeTime);
        //LeanTween.move(gameObject, ,);
    }

    public void FadeIN() {
        LeanTween.alphaCanvas(canvasGroup, 0, fadeTime);

    }
}
