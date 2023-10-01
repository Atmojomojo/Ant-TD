using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerSelect : MonoBehaviour, IPointerDownHandler
{
    public UpgradeTower upgradeTower;
    public GameObject turretUI;
    public GameObject turretCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        upgradeTower = FindAnyObjectByType<UpgradeTower>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            upgradeTower.selectedTower = gameObject;
            turretUI.transform.position = transform.position;
            turretCanvas.GetComponent<Canvas>().enabled = true;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (turretUI == null)
        {
            turretUI = GameObject.Find("TurretUI");
        }
       if (turretCanvas == null)
        {
            turretCanvas = GameObject.Find("TurretCanvas");
        }
    }
}
