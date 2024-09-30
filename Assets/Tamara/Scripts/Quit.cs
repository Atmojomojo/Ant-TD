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
        PlayerPrefs.DeleteKey("Map1");
        Debug.Log("Quit");
        Application.Quit();
        
    }
}
