using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDisplay : MonoBehaviour {

    public GameObject primaryBG, SecondaryBG, devideLine;
    public float transitionTime = 0.5f;

    public Image gunIcon1, gunIcon2;
    public Sprite gunSprite1 => GunManager.instance.primaryGunInfo.icon;
    public Sprite gunSprite2 => GunManager.instance.secondaryGunInfo.icon;

    public static WeaponDisplay instance;
    GameObject primaryGun => GunManager.instance.primaryGunObject;
    GameObject SecondaryGun => GunManager.instance.secondaryGunObject;
    GameObject CurrentGun => GunManager.instance.currentGunObject;
    // Start is called before the first frame update
    void Start() {
        if (instance == null) instance = this;
        else { Destroy(this); }
        EvaluateGuns();
        GunManager.instance.OnWeaponsChanged += EvaluateGuns;
    }

    void EvaluateGuns()
    {     
        if (gunSprite1) {
            gunIcon1.sprite = gunSprite1;
            gunIcon1.gameObject.SetActive(true);
        }
        else
        {
            gunIcon1.gameObject.SetActive(false);
        }
        if (gunSprite2)
        {
            gunIcon2.sprite = gunSprite2;
            gunIcon2.gameObject.SetActive(true);
        }
        else
        {
            gunIcon2.gameObject.SetActive(false);
        }

        if (primaryGun && SecondaryGun)
        {
            if (CurrentGun == primaryGun) { SetGun1Active(); }
            if (CurrentGun == SecondaryGun) { SetGun2Active(); }
        }
        else if (primaryGun) { OnlyPrimary(); }
        else if (SecondaryGun) { OnlySecondary(); }
    }

    public void SetGun1Active() {
        LeanTween.alpha(primaryBG.GetComponent<RectTransform>(), 1f, transitionTime);
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
        LeanTween.alpha(SecondaryBG.GetComponent<RectTransform>(), 0f, transitionTime);
        LeanTween.moveX(devideLine.GetComponent<RectTransform>(), -810, transitionTime);
        gunIcon1.gameObject.SetActive(true);
        gunIcon2.gameObject.SetActive(false);

    }

    public void OnlySecondary() {
        LeanTween.alpha(primaryBG.GetComponent<RectTransform>(), 0f, transitionTime);
        LeanTween.alpha(SecondaryBG.GetComponent<RectTransform>(), 1f, transitionTime);
        LeanTween.moveX(devideLine.GetComponent<RectTransform>(), -518, transitionTime);
        gunIcon1.gameObject.SetActive(false);
        gunIcon2.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        if (GunManager.instance)
        {
            GunManager.instance.OnWeaponsChanged += EvaluateGuns;
            EvaluateGuns();
        }
        
    }

    private void OnDisable()
    {
        GunManager.instance.OnWeaponsChanged -= EvaluateGuns;
    }
}

