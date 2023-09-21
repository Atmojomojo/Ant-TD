using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ASyncLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainmenu;

    [SerializeField] private Slider loadingSlider;

    public void LoadLevelBtn(string map1)
    {
        mainmenu.SetActive(false);
        loadingScreen.SetActive(true);

        //run the ASync
    }

}
