using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Fullscreen : MonoBehaviour
{
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        
    }
}
