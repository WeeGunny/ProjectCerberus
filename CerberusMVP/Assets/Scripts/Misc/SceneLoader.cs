using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    private PlayerStats stats;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));

        PlayerPrefs.GetFloat("Health", stats.Health);
        PlayerPrefs.GetFloat("Moxie", stats.Moxie);
        PlayerPrefs.GetFloat("Grit", stats.Grit);
    }

    IEnumerator LoadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Fills slider based on loading progress
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }

    }
}
