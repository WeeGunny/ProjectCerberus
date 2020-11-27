using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singleton

    public static PlayerManager instance;
    public static bool playerExists =false ;

    private void Awake() {
        instance = this;
        PlayerPrefs.GetFloat("Health");
        PlayerPrefs.GetFloat("Moxie");
        PlayerPrefs.GetFloat("Grit");
    }
    #endregion

    public GameObject player = null;  
    public PlayerStats stats = null;
    public Inventory inventory = null;
}
