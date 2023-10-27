using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class UpgradeTower : MonoBehaviour
{
    public GameObject selectedTower;
    public Currency currency;
    public Canvas canvas;
    public DecalProjector projector;
    public TMP_Text sellText, upgradeText, levelText;
    public float sellValue;
    public float upCost;
    public GameObject upgradeButton;
    public Color startColor;
    public Color maxLevelColor;
    public GameObject image;

    private TowerTarget towerTargetScript;
    private ManualTower manualTowerScript;

    public GameObject nutI, berryI, fireI, sprayI;
    public void Start()
    {
        startColor = upgradeButton.GetComponent<Image>().color;
    }
    public void Update()
    {
        if (selectedTower != null)
        {
            if (selectedTower.GetComponent<TowerTarget>() != null)
            {
                towerTargetScript = selectedTower.GetComponent<TowerTarget>();
                TowerTargetScriptUpdate();
            }
            else if (selectedTower.GetComponent<ManualTower>() != null)
            {
                manualTowerScript = selectedTower.GetComponent<ManualTower>();
                ManualTowerScriptUpdate();
            }
            
        }
    }

    public void TowerTargetScriptUpdate()
    {
        if (towerTargetScript.towerLevel == 1)
        {
            upCost = towerTargetScript.towerSO.upCost2;
            upgradeText.SetText("<b> UPGRADE </b> <br>" + upCost);
            image.GetComponent<Image>().enabled = true;
            sellValue = towerTargetScript.towerSO.cost / 2;
            levelText.SetText("<b> I </b>");
            if (currency.currency < towerTargetScript.towerSO.upCost2)
            {
                upgradeButton.GetComponent<Image>().color = maxLevelColor;
            }
            else
            {
                upgradeButton.GetComponent<Image>().color = startColor;
            }
        }
        else if (towerTargetScript.towerLevel == 2)
        {
            upCost = towerTargetScript.towerSO.upCost3;
            upgradeText.SetText("<b> UPGRADE </b> <br>" + upCost);
            image.GetComponent<Image>().enabled = true;
            sellValue = (towerTargetScript.towerSO.cost / 2) + (towerTargetScript.towerSO.upCost2 / 2);
            levelText.SetText("<b> II </b>");
            if (currency.currency < towerTargetScript.towerSO.upCost3)
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
            image.GetComponent<Image>().enabled = false;
            upgradeButton.GetComponent<Image>().color = maxLevelColor;
            sellValue = towerTargetScript.towerSO.cost / 2;
            sellValue = (towerTargetScript.towerSO.cost / 2) + (towerTargetScript.towerSO.upCost2 / 2) + (towerTargetScript.towerSO.upCost3 / 2);
            levelText.SetText("<b> III </b>");
        }
        sellText.SetText("<b> SELL </b> <br>" + sellValue);
    }

    public void ManualTowerScriptUpdate()
    {
        if (manualTowerScript.towerLevel == 1)
        {
            upCost = manualTowerScript.towerSO.upCost2;
            upgradeText.SetText("<b> UPGRADE </b> <br>" + upCost);
            image.GetComponent<Image>().enabled = true;
            sellValue = manualTowerScript.towerSO.cost / 2;
            levelText.SetText("<b> I </b>");
            if (currency.currency < manualTowerScript.towerSO.upCost2)
            {
                upgradeButton.GetComponent<Image>().color = maxLevelColor;
            }
            else
            {
                upgradeButton.GetComponent<Image>().color = startColor;
            }
        }
        else if (manualTowerScript.towerLevel == 2)
        {
            upCost = manualTowerScript.towerSO.upCost3;
            upgradeText.SetText("<b> UPGRADE </b> <br>" + upCost);
            image.GetComponent<Image>().enabled = true;
            sellValue = (manualTowerScript.towerSO.cost / 2) + (manualTowerScript.towerSO.upCost2 / 2);
            levelText.SetText("<b> II </b>");
            if (currency.currency < manualTowerScript.towerSO.upCost3)
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
            image.GetComponent<Image>().enabled = false;
            upgradeButton.GetComponent<Image>().color = maxLevelColor;
            sellValue = manualTowerScript.towerSO.cost / 2;
            sellValue = (manualTowerScript.towerSO.cost / 2) + (manualTowerScript.towerSO.upCost2 / 2) + (manualTowerScript.towerSO.upCost3 / 2);
            levelText.SetText("<b> III </b>");
        }
        sellText.SetText("<b> SELL </b> <br>" + sellValue);
    }
    public void Upgrade()
    {
        if (selectedTower.GetComponent<TowerTarget>() != null)
        {
            if (towerTargetScript.towerLevel == 1)
            {
                if (currency.currency >= towerTargetScript.towerSO.upCost2)
                {
                    currency.currency -= towerTargetScript.towerSO.upCost2;
                    towerTargetScript.towerLevel = 2;
                    print("test");
                }
            }
            else
            {
                if (currency.currency >= towerTargetScript.towerSO.upCost3)
                {
                    currency.currency -= towerTargetScript.towerSO.upCost3;
                    towerTargetScript.towerLevel = 3;
                    print("test");
                }
            }
        }
        else if (selectedTower.GetComponent<ManualTower>() != null)
        {
            if (manualTowerScript.towerLevel == 1)
            {
                if (currency.currency >= manualTowerScript.towerSO.upCost2)
                {
                    currency.currency -= manualTowerScript.towerSO.upCost2;
                    manualTowerScript.towerLevel = 2;
                    print("test");
                }
            }
            else
            {
                if (currency.currency >= manualTowerScript.towerSO.upCost3)
                {
                    currency.currency -= manualTowerScript.towerSO.upCost3;
                    manualTowerScript.towerLevel = 3;
                    print("test");
                }
            }
        }
    }

    public void Sell()
    {
        currency.currency += sellValue;
        Destroy(selectedTower);
        canvas.enabled = false;
        projector.enabled = false;
    }
}
