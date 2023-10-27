using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretSwitch : MonoBehaviour
{
    public bool turretActive = false;
    public PlayerInput playerInput;
    public Camera main, turret;
    public MountedTurret mountedTurret;
    public MountedTurretShoot shoot;
    public void SwitchToTurret()
    {
        if (turretActive == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            turret.enabled = true;
            main.enabled = false;
            mountedTurret.enabled = true;
            shoot.enabled = true;
            playerInput.defaultActionMap = "MountedTurret";
            playerInput.camera = turret;
            turretActive = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            main.enabled = true;
            turret.enabled = false;
            mountedTurret.enabled = false;
            shoot.enabled = false;
            playerInput.defaultActionMap = "Player";
            playerInput.camera = main;
            turretActive = false;
        }
    }
   
}
