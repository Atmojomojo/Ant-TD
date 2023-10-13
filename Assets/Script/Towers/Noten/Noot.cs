using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noot : MonoBehaviour
{
    public float bulletSpeed, gravity;
    public float damage;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed; // Set the initial forward velocity
    }

    void Update()
    {
        // Simulate gravity (bullet drop) by applying a force in the downward direction
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.health -= damage;
                print("Enemy Hit with noot. It did " + damage + " Damage");
            }
        }
        Destroy(gameObject);
    }
}
