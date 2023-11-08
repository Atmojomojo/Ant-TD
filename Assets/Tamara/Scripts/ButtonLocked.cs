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
        CheckIfScenePlayed();
    }

    void CheckIfScenePlayed()
    {
        if (PlayerPrefs.HasKey(sceneToCheck + "_played"))
        {
            Debug.Log(sceneToCheck + " has been played.");
            // Your logic for when the scene has been played
            level2.interactable = true;
        }
        else
        {
            Debug.Log(sceneToCheck + " has not been played.");
            // Your logic for when the scene has not been played
            level2.interactable = false;
        }

        // Save PlayerPrefs
        PlayerPrefs.Save();
    }

}


