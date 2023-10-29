using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTower : MonoBehaviour
{
    public GameObject[] enemies;
    public TowerSO towerSO;
    public int towerLevel = 1;
    public float damage, range;
    public float angle;
    private float lastAttackTime = 0f; // Track the last attack time
    public Transform attackPoint; // Set the attack point in the Inspector
    public FireTower fireTower;

    // Start is called before the first frame update
    void Start()
    {
        angle = towerSO.coneAngle;
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

        // Check for enemies in range and attack them
        if (Time.time - lastAttackTime >= towerSO.attackspeed)
        {
            List<GameObject> targetsInRange = GetEnemiesInRange();
            if (targetsInRange.Count == 0)
            {
                if (fireTower != null)
                {
                    fireTower.Idle();
                }
            }
            else
            {
                foreach (GameObject target in targetsInRange)
                {
                    if (fireTower != null)
                    {
                        fireTower.Attack(target);
                    }
                }
            }
          
            lastAttackTime = Time.time; // Update the last attack time
        }
    }
    private void OnDrawGizmos()
    {
        // Draw a wireframe sphere to represent the tower's circular range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);

        // Calculate the angle in radians
        float halfAngleRad = angle / 2.0f * Mathf.Deg2Rad;

        // Calculate the points at the edges of the cone
        Vector3 forward = transform.forward;
        Vector3 leftEdge = Quaternion.Euler(0, -angle / 2.0f, 0) * forward;
        Vector3 rightEdge = Quaternion.Euler(0, angle / 2.0f, 0) * forward;

        // Draw lines to connect the edges of the cone to the tower's position
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + leftEdge * range);
        Gizmos.DrawLine(transform.position, transform.position + rightEdge * range);

        // Draw lines to create the outline of the cone
        Gizmos.DrawLine(transform.position + leftEdge * range, transform.position + rightEdge * range);
        Gizmos.DrawLine(transform.position, transform.position + leftEdge * range);
        Gizmos.DrawLine(transform.position, transform.position + rightEdge * range);
    }

    public List<GameObject> GetEnemiesInRange()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> targetsInRange = new List<GameObject>();

        foreach (GameObject go in enemies)
        {
            float currentDistance = Vector3.Distance(transform.position, go.transform.position);

            if (currentDistance <= range)
            {
                // Calculate the angle between the tower's forward direction and the direction to the enemy
                Vector3 toEnemy = go.transform.position - transform.position;
                float angleToEnemy = Vector3.Angle(transform.forward, toEnemy);

                // Check if the enemy is within the cone angle
                if (angleToEnemy <= angle / 2.0f)
                {
                    targetsInRange.Add(go);
                }
            }
        }

        return targetsInRange;
    }
}
