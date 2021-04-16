using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDisplay : MonoBehaviour {

    public GameObject primaryBG, SecondaryBG, devideLine;
    public float transitionTime = 0.5f;

    public Image gunIcon1, gunIcon2;

    public static WeaponDisplay instance;
    // Start is called before the first frame update
    void Start() {
        if (instance == null) instance = this;
        else { Destroy(this); }
    }

    public void SetGunIcon1(Sprite newIcon) {
        if (newIcon != null) {
            gunIcon1.sprite = newIcon;
            gunIcon1.gameObject.SetActive(true);
        }
        else {
            gunIcon1.gameObject.SetActive(false);
        }
    }

    public void SetGunIcon2(Sprite newIcon) {
        if (newIcon != null) {
            gunIcon2.sprite = newIcon;
            gunIcon2.gameObject.SetActive(true);
        }
        else {
            gunIcon2.gameObject.SetActive(false);
        }

    }

    public void SetGun1Active() {
        LeanTween.alpha(primaryBG.GetComponent<RectTransform>(), 1f, transitionTime);
        //LeanTween.move(primaryBG.GetComponent<RectTransform>(), new Vector3(-705, -407, 0), transitionTime);
        LeanTween.alpha(SecondaryBG.GetComponent<RectTransform>(), 0f, transitionTime);
        LeanTween.moveX(devideLine.GetComponent<RectTransform>(), -600, transitionTime);
        gunIcon1.gameObject.SetActive(true);
        gunIcon2.gameObject.SetActive(true);
    }
    public void SetGun2Active() {

        LeanTween.alpha(primaryBG.GetComponent<RectTransform>(), 0f, transitionTime);
        LeanTween.alpha(SecondaryBG.GetComponent<RectTransform>(), 1f, transitionTime);
        LeanTween.moveX(devideLine.GetComponent<RectTransform>(), -724, transitionTime);
        gunIcon1.gameObject.SetActive(true);
        gunIcon2.gameObject.SetActive(true);
    }

    public void OnlyPrimary() {
        LeanTween.alpha(primaryBG.GetComponent<RectTransform>(), 1f, transitionTime);
        //LeanTween.move(primaryBG.GetComponent<RectTransform>(), new Vector3(-665, -407, 0), transitionTime);
        LeanTween.alpha(SecondaryBG.GetComponent<RectTransform>(), 0f, transitionTime);
        LeanTween.moveX(devideLine.GetComponent<RectTransform>(), -810, transitionTime);
        gunIcon1.gameObject.SetActive(true);
        gunIcon2.gameObject.SetActive(false);

    }

    public void OnlySecondary() {
        LeanTween.alpha(primaryBG.GetComponent<RectTransform>(), 0f, transitionTime);
        LeanTween.alpha(SecondaryBG.GetComponent<RectTransform>(), 1f, transitionTime);
        //LeanTween.move(primaryBG.GetComponent<RectTransform>(), new Vector3(-665, -407, 0), transitionTime);
        LeanTween.moveX(devideLine.GetComponent<RectTransform>(), -518, transitionTime);
        gunIcon1.gameObject.SetActive(false);
        gunIcon2.gameObject.SetActive(true);
    }

}

