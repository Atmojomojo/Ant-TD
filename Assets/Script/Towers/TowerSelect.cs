using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSelect : MonoBehaviour, IPointerDownHandler
{
    public bool selected = false;
    public GameObject turretUI;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            selected = true;
            turretUI.transform.position = transform.position;
            turretUI.SetActive(true);
        }
    }

    public void Upgrade()
    {

    }

    public void Sell()
    {

    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
