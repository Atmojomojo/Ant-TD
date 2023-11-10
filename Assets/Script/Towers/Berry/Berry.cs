using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;
    private Rigidbody rb;
    public GameObject splash, lastSplash;

    public GameObject enemyTarget;
    public GameObject target;
    public GameObject arc;
    public GameObject sfx;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = enemyTarget;
    }

    public void Shoot(GameObject target, float damage, GameObject arc)
    {
        enemyTarget = target;
        this.damage = damage;
        this.arc = arc;
    }
    public void Update()
    {
        if (target == arc)
        {
            if (Vector3.Distance(transform.position, arc.transform.position) < 2)
            {
                target = enemyTarget;
            }
        }
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
        rb.velocity = transform.forward * bulletSpeed; // Set the initial forward velocity
    }

    
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.CompareTag("Enemy"))
        {
            Instantiate(sfx, collision.transform.position, collision.transform.rotation);
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            lastSplash = Instantiate(splash, transform.position, Quaternion.Euler(90,0,0));
            lastSplash.GetComponent<SplashDamage>().damage = damage;
        }
        Destroy(gameObject);
    }
}
