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
    public DecalProjector projector, coneProjector;
    public GameObject[] prefab;
    public SelectCircle circle;

    public void Start()
    {
        prefab = (GameObject.FindGameObjectsWithTag("Buildable"));
    }
    public void OnCloseUI()
    {
        projector.enabled = false;
        coneProjector.enabled = false;
        turretCanvas.GetComponent<Canvas>().enabled = false;
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponent<TowerPlacement>().current = null;
            if (prefab[i].GetComponent<TowerPlacement>().bPlaced != null)
            {
                Destroy(prefab[i].GetComponent<TowerPlacement>().bPlaced); prefab[i].GetComponent<TowerPlacement>().bPlaced = null;
            }
        }
        circle.berryI.SetActive(false);
        circle.fireI.SetActive(false);
        circle.nutI.SetActive(false);
        circle.sprayI.SetActive(false);
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
