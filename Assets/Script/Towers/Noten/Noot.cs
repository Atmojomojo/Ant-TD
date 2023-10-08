using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noot : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;
    public void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().health -= damage;
            print("Enemy Hit with noot. It did "+ damage + " Damage");
        }
        Destroy(gameObject);
    }
}
