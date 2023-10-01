using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTarget : MonoBehaviour
{
    public TowerSO towerSO;
    public GameObject closestEnemy;
    public GameObject[] enemies;
    private float timeStamp;
    public GameObject rotatePoint;
    public ParticleSystem particle;
    public float damage, range;
    public int towerLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
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
        closestEnemy = GetClosestEnemy();
        
        if (closestEnemy != null )
        {
            rotatePoint.transform.LookAt( closestEnemy.transform.position );
            if ( Time.time > timeStamp )
            {
                closestEnemy.GetComponent<EnemyAI>().health -= damage;
                particle.Emit(1);
                Debug.Log("Shoot");
                timeStamp = Time.time + towerSO.attackspeed;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
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
