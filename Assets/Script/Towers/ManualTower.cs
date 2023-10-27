using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTower : MonoBehaviour
{
    public TowerSO towerSO;
    public int towerLevel = 1;
    public float damage, range;
    public ParticleSystem fire;
    public GameObject[] enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (towerLevel == 1)
        {
            damage = towerSO.damage1;
            range = towerSO.range1;
        }
        else if (towerLevel == 2)
        {
            damage = towerSO.damage2;
            range = towerSO.range2;
        }
        else
        {
            damage = towerSO.damage3;
            range = towerSO.range3;
        }
    }
   
    public GameObject GetClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject target = null;

        foreach (GameObject go in enemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < range)
            {
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    target = go;
                }
            }
        }
        return target;
    }
}
