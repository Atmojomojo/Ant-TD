using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLocked : MonoBehaviour
{
    public Button level2;
  
    public string sceneToCheck = "Map";

    void Start()
    {
        level2.interactable = false;
        if (!PlayerPrefs.HasKey("Map1"))
        {
            PlayerPrefs.SetInt("Map1", 0);
        }
        CheckIfScenePlayed();
    }

    void CheckIfScenePlayed()
    {
        if (PlayerPrefs.GetInt("Map1") ==1)
        {
            level2.interactable = true;
        }
       
    }

}


