using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class UIClose : MonoBehaviour
{
    public GameObject turretCanvas;
    private InputAction action;
    public UpgradeTower upgradeTower;
    public DecalProjector projector;
    public void OnCloseUI()
    {
        projector.enabled = false;
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
