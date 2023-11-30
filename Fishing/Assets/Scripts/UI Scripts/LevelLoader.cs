using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
    //naomi
{ 
    public GameObject loadingScreen;
    public Slider slider;

    public void LoadLevel(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
        
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
