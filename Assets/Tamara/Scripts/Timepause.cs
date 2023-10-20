using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.InputSystem;


public class Timepause : MonoBehaviour
{
    private bool isPaused = false;

    public Canvas ingameUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeTime();
            }
            else
            {
                PauseTime();
            }
        }
    }

    void PauseTime()
    {
        Time.timeScale = 0; 
        isPaused = true;
    }

    void ResumeTime()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    
    public void OpenCanvas()
    {
        ingameUI.gameObject.SetActive(true);
        PauseTime();
    }

    
    public void CloseCanvas()
    {
        ingameUI.gameObject.SetActive(false);
        ResumeTime();
    }
}
