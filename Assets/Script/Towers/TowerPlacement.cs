using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TowerPlacement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Vector3 positionOffset;
    public Currency currency;
    public Color hoverColor;

    public GameObject nut, berry, fire, spray, current;

    private bool turret;

    public GameObject rend;
    private Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        SelectNut();
        startColor = rend.GetComponent<Renderer>().material.color;
        currency = FindObjectOfType<Currency>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rend.GetComponent<Renderer>().material.color = hoverColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (turret == false)
            {
                if (current.GetComponent<TowerTarget>().towerSO.cost <= currency.currency)
                {
                    Instantiate(current, transform.position + positionOffset, transform.rotation);
                    turret = true;
                    currency.currency -= current.GetComponent<TowerTarget>().towerSO.cost;
                }
            }
        }
    }
   
    public void OnPointerExit(PointerEventData eventData)
    {
        rend.GetComponent<Renderer>().material.color = startColor;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectNut()
    {
        current = nut;
    }
    public void SelectBerry()
    {
        current = berry;
    }
    public void SelectFire()
    {
        current = fire;
    }

    public void SelectSpray()
    {
        current = spray;
    }
}
