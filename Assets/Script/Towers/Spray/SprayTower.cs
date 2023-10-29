using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayTower : MonoBehaviour
{
    public ManualTower manual;
    public Animator animator;
    public GameObject attackParticle;
    private ParticleSystem.MainModule mainModule;

    public void Start()
    {
        mainModule = attackParticle.GetComponent<ParticleSystem>().main;
    }

    public void ParticleRange2()
    {
        mainModule.startLifetime = 3.5f;
    }

    public void ParticleRange3()
    {
        mainModule.startLifetime = 5;
    }
    public void Attack(GameObject target)
    {
        animator.SetTrigger("Attack");
        attackParticle.SetActive(true);
        if (Time.time > target.GetComponent<EnemyAI>().sprayTimeStamp)
        {
            target.GetComponent<EnemyAI>().hitParticle.Play();
            target.GetComponent<EnemyAI>().health -= manual.damage;
            target.GetComponent<EnemyAI>().sprayTimeStamp = Time.time + manual.towerSO.cooldownTime;
        }
    }

    public void Idle()
    {
        attackParticle.SetActive(false);
    }
}
