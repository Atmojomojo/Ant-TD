using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryTower : MonoBehaviour
{
    public ManualTower manualTower;
    public GameObject bullet;
    public Animator animator;
    public Transform attackPoint;
    public void Attack()
    {
        animator.SetTrigger("Attack");
        Instantiate(bullet, attackPoint.position, attackPoint.rotation);
    }
}
