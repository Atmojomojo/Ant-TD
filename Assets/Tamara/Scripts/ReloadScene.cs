using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private Scene scene;
    public GameObject Loadingscreen;
    public Image LoadingBarFill;
    public Slider slider;

    public float loadingScreenDuration = 0.8f;
    public void LoadScene()
    {
        scene = SceneManager.GetActiveScene();
        StartCoroutine(LoadSceneAsync(scene.buildIndex));
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {
        Loadingscreen.SetActive(true);

        yield return new WaitForSeconds(loadingScreenDuration);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);


        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            //LoadingBarFill.fillAmount = progressValue;
            slider.value = progressValue;
            yield return null;
        }
    }

}
