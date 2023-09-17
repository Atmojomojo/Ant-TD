using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject defendPoint;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        defendPoint = GameObject.Find("DefendPoint");
        agent.SetDestination(defendPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }   
    }
}
