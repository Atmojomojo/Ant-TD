using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noot : MonoBehaviour
{
    public float bulletSpeed;
    public void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().health -= 0;
        }
        Destroy(gameObject);
    }
}
