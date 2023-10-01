using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeTower : MonoBehaviour
{
    public GameObject selectedTower;
    public Currency currency;
    public Canvas canvas;
    public TMP_Text sellText, upgradeText;
    public float sellValue;
    public float upCost;
    public GameObject upgradeButton;
    public Color startColor;
    public Color maxLevelColor;

    public void Start()
    {
        startColor = upgradeButton.GetComponent<Image>().color;
    }
    public void Update()
    {
        if (selectedTower != null)
        {
            if (selectedTower.GetComponent<TowerTarget>().towerLevel == 1)
            {
                upCost = selectedTower.GetComponent<TowerTarget>().towerSO.upCost2;
                upgradeText.SetText("<b> UPGRADE </b> <br>$" + upCost);
                sellValue = selectedTower.GetComponent<TowerTarget>().towerSO.cost / 2;
                if (currency.currency < selectedTower.GetComponent<TowerTarget>().towerSO.upCost2)
                {
                    upgradeButton.GetComponent<Image>().color = maxLevelColor;
                }
                else
                {
                    upgradeButton.GetComponent<Image>().color = startColor;
                }
            }
            else if (selectedTower.GetComponent<TowerTarget>().towerLevel == 2)
            {
                upCost = selectedTower.GetComponent<TowerTarget>().towerSO.upCost3;
                upgradeText.SetText("<b> UPGRADE </b> <br>$" + upCost);
                sellValue = (selectedTower.GetComponent<TowerTarget>().towerSO.cost / 2) + (selectedTower.GetComponent<TowerTarget>().towerSO.upCost2 / 2);
                if (currency.currency < selectedTower.GetComponent<TowerTarget>().towerSO.upCost3)
                {
                    upgradeButton.GetComponent<Image>().color = maxLevelColor;
                }
                else
                {
                    upgradeButton.GetComponent<Image>().color = startColor;
                }
            }
            else
            {
                upgradeText.SetText("<b> MAX <br> UPGRADE </b>");
                upgradeButton.GetComponent<Image>().color = maxLevelColor;
                sellValue = selectedTower.GetComponent<TowerTarget>().towerSO.cost / 2;
                sellValue = (selectedTower.GetComponent<TowerTarget>().towerSO.cost / 2) + (selectedTower.GetComponent<TowerTarget>().towerSO.upCost2 / 2) + (selectedTower.GetComponent<TowerTarget>().towerSO.upCost3 / 2);
            }
            sellText.SetText("<b> SELL </b> <br>$" + sellValue);
        }
    }
    public void Upgrade()
    {
        if (selectedTower.GetComponent<TowerTarget>().towerLevel == 1)
        {
            if (currency.currency >= selectedTower.GetComponent<TowerTarget>().towerSO.upCost2)
            {
                currency.currency -= selectedTower.GetComponent<TowerTarget>().towerSO.upCost2;
                selectedTower.GetComponent<TowerTarget>().towerLevel = 2;
                print("test");
            }
        }
        else
        {
            if (currency.currency >= selectedTower.GetComponent<TowerTarget>().towerSO.upCost3)
            {
                currency.currency -= selectedTower.GetComponent<TowerTarget>().towerSO.upCost3;
                selectedTower.GetComponent<TowerTarget>().towerLevel = 3;
                print("test");
            }
        }
    }

    public void Sell()
    {
        currency.currency += sellValue;
        Destroy(selectedTower);
        canvas.enabled = false;
    }
}
