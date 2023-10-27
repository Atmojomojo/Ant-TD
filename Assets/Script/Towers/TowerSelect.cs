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
    public GameObject leftui, rightui;
    public float range;

    
    // Start is called before the first frame update
    void Start()
    {
        upgradeTower = FindAnyObjectByType<UpgradeTower>();
        projector = GameObject.Find("Decal Tower Range");
        leftui = GameObject.Find("Left");
        rightui = GameObject.Find("Right");
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
            upgradeTower.nutI.SetActive(false);
            upgradeTower.berryI.SetActive(false);
            upgradeTower.fireI.SetActive(false);
            upgradeTower.sprayI.SetActive(false);
            if (gameObject.name == "Noten V2(Clone)")
            {
                leftui.GetComponent<Image>().enabled = false;
                leftui.GetComponent<Button>().enabled = false;
                rightui.GetComponent<Image>().enabled = false;
                rightui.GetComponent<Button>().enabled = false;
            }
            else
            {
                leftui.GetComponent<Image>().enabled = true;
                leftui.GetComponent<Button>().enabled = true;
                rightui.GetComponent<Image>().enabled = true;
                rightui.GetComponent<Button>().enabled = true;
            }
        }
    }

    public void RotateLeft()
    {
        upgradeTower.selectedTower.transform.Rotate(Vector3.up * 90);
    }

    public void RotateRight()
    {
        upgradeTower.selectedTower.transform.Rotate(Vector3.down * 90);
    }
    // Update is called once per frame
    void Update()
    {
       if (upgradeTower.selectedTower != null)
       {
            if (upgradeTower.selectedTower.GetComponent<TowerTarget>() != null)
            {
                range = upgradeTower.selectedTower.GetComponent<TowerTarget>().range;
                projector.GetComponent<DecalProjector>().size = new Vector3(range + range, range + range, 1f);
            }
            else if (upgradeTower.selectedTower.GetComponent<ManualTower>() != null)
            {
                range = upgradeTower.selectedTower.GetComponent<ManualTower>().range;
                // Projector van manual tower moet een cone shape hebben ipv circkel
                projector.GetComponent<DecalProjector>().size = new Vector3(range + range, range + range, 1f);
            }
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
