using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public Currency currency;
    public void DevTool1()
    {
        Time.timeScale = 1;
    }
    public void DevTool2()
    {
        Time.timeScale = 3;
    }
    public void DevTool3()
    {
        Time.timeScale = 6;
    }
    public void DevToolMoney()
    {
        currency.currency += 250;
    }
}
