﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    private static PlayerStats stats;
    private static PlayerManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Main");

            PlayerPrefs.SetFloat("Health", stats.Health);
            PlayerPrefs.SetFloat("Moxie", stats.Moxie);
            PlayerPrefs.SetFloat("Grit", stats.Grit);

            DontDestroyOnLoad(stats);
            DontDestroyOnLoad(manager);
        }
    }
}
