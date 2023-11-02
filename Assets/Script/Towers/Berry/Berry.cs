using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    public float bulletSpeed;
    public float damage;
    private Rigidbody rb;
    public GameObject splash;

    public Transform target;
    public Transform arc1, arc2, arc3;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed; // Set the initial forward velocity
    }

    public void Update()
    {
        gameObject.transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "arc1")
        {
            target = arc2;
        }
        if (other.transform.name == "arc2")
        {
            target = arc3;
        }
        if (other.transform.name == "arc3")
        {
            target = enemySpawn.enemies[0].transform;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            Instantiate(splash, transform.position, Quaternion.identity);
            if (enemy != null)
            {
                enemy.health -= damage;
                enemy.hitParticle.Play();
                print("Enemy Hit with noot. It did " + damage + " Damage");
            }
        }
        Destroy(gameObject);
    }
}
