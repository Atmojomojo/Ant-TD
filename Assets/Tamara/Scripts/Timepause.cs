using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class TimePause : MonoBehaviour
{
    
    private bool isPaused = false;
    public VolumeProfile profile;
    private DepthOfField dof;

    public void PauseTime()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            //profile.TryGet<DepthOfField>(out dof);
            //{
            //    dof.gaussianStart.value = 0;
            //    dof.gaussianEnd.value = 0;
            //}
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
            //profile.TryGet<DepthOfField>(out dof);
            //{
            //    dof.gaussianStart.value = 62;
            //    dof.gaussianEnd.value = 90;
            //}
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




