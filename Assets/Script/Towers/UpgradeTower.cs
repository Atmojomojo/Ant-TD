using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject selectedTower;
    public Currency currency;
    public Canvas canvas;
    public TMP_Text sellValue, upgradeValue;

    public void Update()
    {

        sellValue.SetText("<b> SELL </b> <br>$" + selectedTower.GetComponent<TowerTarget>().towerSO.cost / 2);
    }
    public void Upgrade()
    {

    }

    public void Sell()
    {
        currency.currency += selectedTower.GetComponent<TowerTarget>().towerSO.cost / 2;
        Destroy(selectedTower);
        canvas.enabled = false;
    }
}
