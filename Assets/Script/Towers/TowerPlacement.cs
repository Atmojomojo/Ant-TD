using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class TowerPlacement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject[] prefab;
    public Vector3 positionOffset;
    public Currency currency;
    public Color hoverColor;
    public GameObject turretCanvas;
    public GameObject turret;
    public GameObject projector;


    public GameObject bNut, bBerry, bFire, bSpray, bCurrent, bPlaced;

    public GameObject nut, berry, fire, spray, current;


    public GameObject rend;
    private Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        projector = GameObject.Find("Decal Tower Range");
        prefab = (GameObject.FindGameObjectsWithTag("Buildable"));
        turretCanvas = GameObject.Find("TurretCanvas");
        startColor = rend.GetComponent<Renderer>().material.color;
        currency = FindObjectOfType<Currency>();
       
    }
    public void SelectNut()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponent<TowerPlacement>().current = nut;
        }
        turretCanvas.GetComponent<Canvas>().enabled = false;
        projector.GetComponent<DecalProjector>().enabled = false;
    }
    public void SelectBerry()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponent<TowerPlacement>().current = berry;
        }
        turretCanvas.GetComponent<Canvas>().enabled = false;
        projector.GetComponent<DecalProjector>().enabled = false;
    }
    public void SelectFire()
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponent<TowerPlacement>().current = fire;
        }
        turretCanvas.GetComponent<Canvas>().enabled = false;
        projector.GetComponent<DecalProjector>().enabled = false;
    }

    public void SelectSpray()
    {

        for (int i = 0; i < prefab.Length; i++)
        {
            prefab[i].GetComponent<TowerPlacement>().current = spray;
        }
        turretCanvas.GetComponent<Canvas>().enabled = false;
        projector.GetComponent<DecalProjector>().enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (current != null)
        {
            if (turret == null)
            {
                bPlaced = Instantiate(bCurrent, transform.position, transform.rotation);
                rend.GetComponent<Renderer>().material.color = hoverColor;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (current != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (turret == null)
                {
                    if (current.GetComponent<TowerTarget>().towerSO.cost <= currency.currency)
                    {
                        
                        turret = Instantiate(current, transform.position, transform.rotation);
                        currency.currency -= current.GetComponent<TowerTarget>().towerSO.cost;
                    }
                }
            }
        }
    }
   
    public void OnPointerExit(PointerEventData eventData)
    {
        if (bPlaced != null)
        {
            Destroy(bPlaced); bPlaced = null;
        }
        rend.GetComponent<Renderer>().material.color = startColor;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (current!= null)
        {
            if (current == nut)
            {
                bCurrent = bNut;
            }
            else if (current == berry)
            {
                bCurrent = bBerry;
            }
            else if (current == fire)
            {
                bCurrent = fire;
            }
            else if (current == spray)
            {
                bCurrent = spray;
            }
            if (turretCanvas.GetComponent<Canvas>().enabled == true)
            {
                print("test");
                current = null;
            }
        }
    }
}
