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
    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
    }
    
    // Update is called once per frame
    void Update()
    {
        closestEnemy = GetClosestEnemy();
        
        if (closestEnemy != null )
        {
            rotatePoint.transform.LookAt( closestEnemy.transform.position );
            if ( Time.time > timeStamp )
            {
                closestEnemy.GetComponent<EnemyAI>().health -= towerSO.damage;
                particle.Emit(1);
                Debug.Log("Shoot");
                timeStamp = Time.time + towerSO.attackspeed;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, towerSO.range);
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
            if (currentDistance < towerSO.range)
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
