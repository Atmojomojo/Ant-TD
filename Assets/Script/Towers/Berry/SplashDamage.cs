using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDamage : MonoBehaviour
{
    public float damage;
    public GameObject[] enemies;
    public GameObject particle;
    public void Start()
    {
        DealDamage();
    }
    public void DealDamage()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in enemies)
        {
            float currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < 3)
            {
                go.GetComponent<EnemyAI>().health -= damage;
                Instantiate(particle, go.transform.position, go.transform.rotation);
            }
        }
    }
}
