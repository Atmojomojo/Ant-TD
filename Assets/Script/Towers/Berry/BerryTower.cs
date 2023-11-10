using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryTower : MonoBehaviour
{
    public ManualTower manualTower;
    public GameObject bullet;
    public Animator animator;
    public Transform attackPoint;
    public GameObject bulletShot;
    public GameObject arc;
    public GameObject sfx;
    public void Attack(GameObject target, float damage)
    {
        Instantiate(sfx, gameObject.transform.position, gameObject.transform.rotation);
        animator.SetTrigger("Attack");
        bulletShot = Instantiate(bullet, attackPoint.position, attackPoint.rotation);
        bulletShot.GetComponent<Berry>().Shoot(target, damage, arc);
    }

}
