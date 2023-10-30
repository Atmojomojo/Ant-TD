using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaadje : MonoBehaviour
{
    public float bulletSpeed = 16, gravity = 0.5f;
    public float damage =0.2f;
    private Rigidbody rb;

    void Start()
    {
        bulletSpeed = 16;
        gravity = 0.5f;
        damage = 0.2f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.up * bulletSpeed; // Set the initial forward velocity
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
