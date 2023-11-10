using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayTower : MonoBehaviour
{
    public ManualTower manual;
    public Animator animator;
    public GameObject attackParticle;
    private ParticleSystem.MainModule mainModule;
    public GameObject particle;
    public GameObject sfx;
    public AudioSource gasSfx;

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
        gasSfx.Play();
        attackParticle.SetActive(true);
        if (Time.time > target.GetComponent<EnemyAI>().sprayTimeStamp)
        {

            Instantiate(sfx, target.transform.position, target.transform.rotation);
            Instantiate(particle, target.transform.position, target.transform.rotation);
            target.GetComponent<EnemyAI>().health -= manual.damage;
            target.GetComponent<EnemyAI>().sprayTimeStamp = Time.time + manual.towerSO.cooldownTime;
        }
    }

    public void Idle()
    {
        gasSfx.Stop();
        attackParticle.SetActive(false);
    }
}
