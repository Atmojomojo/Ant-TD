using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Currency currency;
    public NavMeshAgent agent;
    public GameObject defendPoint;
    public float health;
    public float worth;
    public float interestBonus;
    public int damage;
    public Health playerHealth;
    private float timeStamp;
    public float attackCooldown;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currency = GameObject.FindAnyObjectByType<Currency>();
        defendPoint = GameObject.Find("DefendPoint");
        agent.SetDestination(defendPoint.transform.position);
        playerHealth = GameObject.FindAnyObjectByType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (currency.currency < currency.interest1)
            {
                currency.currency += worth;
            }
            else if (currency.currency >= currency.interest1 && currency.currency < currency.interest2)
            {
                currency.currency += worth;
                currency.currency += interestBonus;
            }
            else if (currency.currency >= currency.interest2 && currency.currency < currency.interest3)
            {
                currency.currency += worth;
                currency.currency += interestBonus + interestBonus;
            }
            else if (currency.currency >= currency.interest3 && currency.currency < currency.interest4)
            {
                currency.currency += worth;
                currency.currency += interestBonus + interestBonus + interestBonus;
            }
            else if (currency.currency >= currency.interest4 && currency.currency < currency.interest5)
            {
                currency.currency += worth;
                currency.currency += interestBonus + interestBonus + interestBonus + interestBonus;
            }
            else
            {
                currency.currency += worth;
                currency.currency += interestBonus + interestBonus + interestBonus + interestBonus + interestBonus;
            }
            Destroy(gameObject);
        }
        if (Vector3.Distance(gameObject.transform.position, defendPoint.transform.position) < 2f)
        {
            playerHealth.health -= damage;
            Destroy(gameObject);
        }
    }
}
