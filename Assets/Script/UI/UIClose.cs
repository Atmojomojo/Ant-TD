using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIClose : MonoBehaviour
{
    public GameObject turretUI;
    private InputAction action;
    public void OnCloseUI()
    {
        turretUI.SetActive(false);
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
