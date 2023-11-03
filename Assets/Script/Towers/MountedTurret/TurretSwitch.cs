using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TurretSwitch : MonoBehaviour
{
    public bool turretActive = false;
    public PlayerInput playerInput;
    public Camera main, turret;
    public MountedTurret mountedTurret;
    public MountedTurretShoot shoot;



    public GameObject inGameUI;
    public GameObject MountedturretShootUI;
    public GameObject MountedturretLeaveUI;


    public float hideShootUIDelayInSeconds = 4f;
    public float showLeaveUIDelayInSeconds = 6f;
    public float hideLeaveUIDelayInSeconds = 3f;

    private bool isShootUIHidden = false;
    private bool hasEnteredTurret = false;


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

            inGameUI.SetActive(true);
            Debug.Log("MountedturretShootUI");
            MountedturretShootUI.SetActive(true);

            if (!hasEnteredTurret)
            {
                
                hasEnteredTurret = true;

                if (showLeaveUIDelayInSeconds > 0)
                {
                    Invoke("ShowMountedturretLeaveUI", showLeaveUIDelayInSeconds);
                }
            }

            if (hideShootUIDelayInSeconds > 0)
            {
                Invoke("HideMountedturretShootUI", hideShootUIDelayInSeconds);
                
            }
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

            
            inGameUI.SetActive(false);
            MountedturretShootUI.SetActive(false);
            MountedturretLeaveUI.SetActive(false);

            if (hideLeaveUIDelayInSeconds > 0)
            {
                CancelInvoke("ShowMountedturretLeaveUI");
                Invoke("HideMountedturretLeaveUI", hideLeaveUIDelayInSeconds);
            }

            
            hasEnteredTurret = false;
            

        }

    }
    void HideMountedturretShootUI()
    {
        MountedturretShootUI.SetActive(false);
        isShootUIHidden = true;

        if (showLeaveUIDelayInSeconds > 0)
        {
            Invoke("ShowMountedturretLeaveUI", showLeaveUIDelayInSeconds);
        }
    }

    void ShowMountedturretLeaveUI()
    {
        MountedturretLeaveUI.SetActive(true);

        if (hideLeaveUIDelayInSeconds > 0)
        {
            Invoke("HideMountedturretLeaveUI", hideLeaveUIDelayInSeconds);
        }
    }

    void HideMountedturretLeaveUI()
    {
        MountedturretLeaveUI.SetActive(false);
    }
}



