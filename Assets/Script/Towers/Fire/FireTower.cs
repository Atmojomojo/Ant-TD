using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    public ManualTower manual;
    public Animator animator;
    public GameObject attackParticle, idleParticle;
    public void Attack(GameObject target)
    {
        animator.SetTrigger("Attack");
        attackParticle.SetActive(true);
        idleParticle.SetActive(false);
        target.GetComponent<EnemyAI>().fireTicks = 5;
        if (target.GetComponent<EnemyAI>().fireTicks > 0)
        {
            if (target.GetComponent<EnemyAI>().fireDamage < manual.damage)
            {
                target.GetComponent<EnemyAI>().fireDamage = manual.damage;
            }
        }
        else
        {
            target.GetComponent<EnemyAI>().fireDamage = manual.damage;
        }
    }

    public void Idle()
    {
        idleParticle.SetActive(true);
        attackParticle.SetActive(false);
    }
}
