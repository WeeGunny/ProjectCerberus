﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singleton

    public static PlayerManager instance;
    public static bool playerExists =false ;

    private void Awake() {
        instance = this;
    }
    #endregion

    public GameObject player;
    public PlayerStats stats;
}
