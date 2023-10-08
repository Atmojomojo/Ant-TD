using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class TowerSelect : MonoBehaviour, IPointerDownHandler
{
    public UpgradeTower upgradeTower;
    public GameObject turretUI;
    public GameObject turretCanvas;
    public GameObject projector;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        upgradeTower = FindAnyObjectByType<UpgradeTower>();
        projector = GameObject.Find("Decal Tower Range");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            upgradeTower.selectedTower = gameObject;
            projector.GetComponent<DecalProjector>().enabled = true;
            projector.transform.position = transform.position + new Vector3 (0, 0.5f, 0);
            turretUI.transform.position = transform.position;
            turretCanvas.GetComponent<Canvas>().enabled = true;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (upgradeTower.selectedTower != null)
        {
            range = upgradeTower.selectedTower.GetComponent<TowerTarget>().range;
            projector.GetComponent<DecalProjector>().size = new Vector3(range + range, range + range, 1f);
        }
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
