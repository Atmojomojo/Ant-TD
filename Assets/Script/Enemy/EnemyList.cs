using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public bool lastWaveSend;
    public GameObject winScreen;

    // Update is called once per frame
    void Update()
    {
       if (lastWaveSend == true)
        {
            if (enemies.Count == 0)
            {
                winScreen.SetActive(true);
            }
        } 
    }
}
