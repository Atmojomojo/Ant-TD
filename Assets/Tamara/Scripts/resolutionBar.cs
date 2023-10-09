using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;


public class ResolutionBar : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;
    void Start()
    {
        //resolutions = //Screen.resolutions;
        resolutions = new Resolution[]
        {
            new Resolution(),
            new Resolution(),
            new Resolution(),
            new Resolution(),
            new Resolution()
        };
        
        resolutions[0].width = 1280;
        resolutions[0].height = 720;
        resolutions[1].width = 1440;
        resolutions[1].height = 900;
        resolutions[2].width = 1366;
        resolutions[2].height = 720;
        resolutions[3].width = 1920;
        resolutions[3].height = 1080;
        resolutions[4].width = 2560;
        resolutions[4].height = 1440;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = resolutions.Length - 1;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.value = resolutions.Length - 1;
        Screen.fullScreen = true;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetRes ()
    {
        SetResolution(resolutionDropdown.value);
    }

}
