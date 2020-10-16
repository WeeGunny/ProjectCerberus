using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    private PlayerStats stats;
    private PlayerManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("Health", stats.Health);
            PlayerPrefs.SetFloat("Moxie", stats.Moxie);
            PlayerPrefs.SetFloat("Grit", stats.Grit);

            DontDestroyOnLoad(stats);
            DontDestroyOnLoad(manager);

            SceneManager.UnloadSceneAsync("Main");
            SceneManager.LoadScene("Main");

            SceneLoaded();
        }
    }

    void SceneLoaded()
    {
        PlayerPrefs.GetFloat("Health", stats.Health);
        PlayerPrefs.GetFloat("Moxie", stats.Moxie);
        PlayerPrefs.GetFloat("Grit", stats.Grit);
    }
}
