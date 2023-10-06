using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noot : MonoBehaviour
{
    public void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = ;
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
