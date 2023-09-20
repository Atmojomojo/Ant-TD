using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }
}
