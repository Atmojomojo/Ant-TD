using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIClose : MonoBehaviour
{
    public GameObject turretCanvas;
    private InputAction action;
  
    public void OnCloseUI()
    {
        turretCanvas.GetComponent<Canvas>().enabled = false;
    }
    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
