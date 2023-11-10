using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    public ManualTower manual;
    public Animator animator;
    public GameObject attackParticle, idleParticle;
    private ParticleSystem.MainModule mainModule, mainModule2;
    private ParticleSystem.EmissionModule emissionMod, emissionMod2;
    public ParticleSystem particleMain, particleAdd;
    public AudioSource fireSfx;
    public void Start()
    {
        mainModule = particleMain.main;
        mainModule2 = particleAdd.main;
        emissionMod = particleMain.emission;
        emissionMod2 = particleAdd.emission;
    }

    public void ParticleRange2()
    {
        emissionMod.rateOverTime = 20f;
        emissionMod2.rateOverTime = 20f;
        mainModule.startSpeed = 2f;
        mainModule2.startSpeed = 2f;
    }

    public void ParticleRange3()
    {
        emissionMod.rateOverTime = 20f;
        emissionMod2.rateOverTime = 25f;
        mainModule.startSpeed = 2.5f;
        mainModule2.startSpeed = 2.5f;
    }
    public void Attack(GameObject target)
    {
        fireSfx.Play();
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
        fireSfx.Stop();
        idleParticle.SetActive(true);
        attackParticle.SetActive(false);
    }
}
