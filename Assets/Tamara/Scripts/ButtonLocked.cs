using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonLocked : MonoBehaviour
{
    public Button level2;
    private bool isFirstLevelCompleted = false;
    
    void Start()
    {
        level2.interactable = false;
    }

    void Update()
    {
         Debug.Log(SceneManager.GetActiveScene().name);

        if (isFirstLevelCompleted)
        {
            level2.interactable = true;
        }
    }

    public void FirstLevelCompleted()
    {
        isFirstLevelCompleted = true;
    }
}
