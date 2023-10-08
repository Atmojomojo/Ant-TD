using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    public void ToggleFullscreen() 
    {
        Screen.fullScreen = !Screen.fullScreen;
    
    }
}
