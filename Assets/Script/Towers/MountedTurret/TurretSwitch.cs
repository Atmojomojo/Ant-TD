using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TurretSwitch : MonoBehaviour
{
    public bool tutorialHappend;
    public bool turretActive = false;
    public PlayerInput playerInput;
    public Camera main, turret;
    public MountedTurret mountedTurret;
    public MountedTurretShoot shoot;
    

    public GameObject inGameUI;
    public GameObject mountedTurretShootUI;
    public GameObject mountedTurretLeaveUI;
    public GameObject popupUI;
    public string targetSceneName = "Map";


    private bool hasSeenUI = false;


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
            if (tutorialHappend == false)
            {
                StartCoroutine(SwitchToTurretIE());
            }


            inGameUI.SetActive(true); // Crosshair aan

            if (popupUI != null && popupUI.activeSelf)
            {
                HidePopup();
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
            mountedTurretLeaveUI.SetActive(false);

            if (popupUI != null && popupUI.activeSelf)
            {
                HidePopup();
            }

        }
    }
    public IEnumerator SwitchToTurretIE()
    {

        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == targetSceneName)
        {
            yield return new WaitForSeconds(1f);

            mountedTurretShootUI.SetActive(true); // Uitleg aan

            yield return new WaitForSeconds(2f); // Wacht 2 seconden

            mountedTurretShootUI.SetActive(false); // Uitleg uit

            yield return new WaitForSeconds(2f); // Wacht 2 seconden

            mountedTurretLeaveUI.SetActive(true); // Uitleg 2 aan

            yield return new WaitForSeconds(5f); // Wacht 5 seconden

            mountedTurretLeaveUI.SetActive(false); // Uitelg 2 uit
        }
        tutorialHappend = true;
        yield break;
    }
    private void HidePopup()
    {
         popupUI.SetActive(false);
    }
}



