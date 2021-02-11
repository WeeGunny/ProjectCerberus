using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public static SceneLoader instance;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    //Load the next scene while the current one is still active
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
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
