using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    NavMeshAgent navMeshAgent;
    public float chaseRange = 10f;
    public float distanceToTarget = Mathf.Infinity;
    public bool isProvkoed;
    public Animator animator;
    PlayerHealth playerHealth;
    public float demage = 1f;
    bool isWalk = false;
    bool isAttack = false;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isAlive)
        {
            if (isProvkoed)
            {
                EngageTarget();
            }
            else if (distanceToTarget < chaseRange)
            {
                isProvkoed = true;
            }
        }
        else
        {
            navMeshAgent.enabled = false;
        }

    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        if (distanceToTarget > chaseRange && !isWalk)
        {
            animator.SetTrigger("Rest_1");
            isWalk = false;
            isProvkoed = false;
        }
    }

    private void ChaseTarget()
    {
        if (!isWalk)
        {
            animator.SetTrigger("Walk_Cycle_1");
        }
        isWalk = true;
        isAttack = false;
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        if (!isAttack)
        {
            StartCoroutine("WaitForFinishAttackProcss");
            animator.SetTrigger("Attack_1");
            playerHealth.GetComponent<PlayerHealth>().TakeDemage(demage);

        }
        isWalk = false;
    }

    IEnumerator WaitForFinishAttackProcss()
    {
        isAttack = true;
        yield return new WaitForSeconds(1);
        isAttack = false;
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    
    public void OnDamageTaken()
    {
        isProvkoed = true;
    }
}
