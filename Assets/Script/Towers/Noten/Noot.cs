using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noot: MonoBehaviour
{
    public float bulletSpeed;
    public float damage;
    private Rigidbody rb;
    public GameObject sfx;
    public GameObject particle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed; // Set the initial forward velocity
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.health -= damage;
                Instantiate(sfx, collision.transform.position, collision.transform.rotation);
                Instantiate(particle, collision.transform.position, collision.transform.rotation);
            }
        }
        Destroy(gameObject);
    }
}


