using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UIElements;

public class DmgPopUp : MonoBehaviour
{
    private TextMeshPro text;
    public GameObject popUpPrefab;
    public static GameObject popUpStatic;

    public static DmgPopUp Create(Vector3 position,float damage) {
        GameObject popUp = Instantiate(popUpStatic,position,Quaternion.identity);
        DmgPopUp dmgPopUp = popUp.GetComponent<DmgPopUp>();
        dmgPopUp.SetUp(damage);
        return dmgPopUp;
        
    }
    private void Awake() {
        text = GetComponent<TextMeshPro>();
       
    }
    public void SetUp(float damage) {
        text.SetText(damage.ToString());
    }
}
