using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1Win : MonoBehaviour
{
    public void Mapwin()
    {
        if (PlayerPrefs.HasKey("Map1"))
        {
            PlayerPrefs.SetInt("Map1", 1);
        }
    }
}
