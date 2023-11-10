using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
//using UnityEngine.Rendering.HighDefinition;

public class TimePause : MonoBehaviour
{
    
    private bool isPaused = false;
    public VolumeProfile profile;
    private DepthOfField dof;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Tamara")
        {
            profile.TryGet<DepthOfField>(out dof);
            {
                dof.gaussianStart.value = 40;
                dof.gaussianEnd.value = 70;
            }
        }
        else
        {
            BlurInGame();
        }
        
    }
    public void PauseTime()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
   
        }
    }

    public void BlurInMenu()
    {
        profile.TryGet<DepthOfField>(out dof);
        {
            dof.gaussianStart.value = 0;
            dof.gaussianEnd.value = 0;
        }
    }

    public void ResumeTime()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
      
        }
    }

    public void BlurInGame()
    {
        profile.TryGet<DepthOfField>(out dof);
        {
            dof.gaussianStart.value = 62;
            dof.gaussianEnd.value = 90;
        }
    }
}




