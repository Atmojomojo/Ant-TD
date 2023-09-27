using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject Loadingscreen;
    public Image LoadingBarFill;
    public Slider slider;

    public float loadingScreenDuration = 0.8f;
    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {
        yield return new WaitForSeconds(loadingScreenDuration);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        
        Loadingscreen.SetActive(true);

        while(!operation.isDone) 
        { 
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            //LoadingBarFill.fillAmount = progressValue;
            slider.value = progressValue;
            yield return null;
        }
    }

}
