using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WarriorController : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    private float coolDownAttack;

    [SerializeField]
    private Collider colliderAttack;

    [SerializeField]
    private int distanceAttackPlayer = 3;

    private float timer;

    private bool hasAttacked = false;

    private NavMeshAgent navMeshAgent;

    public bool animAttackIsFinished;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        colliderAttack.enabled = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animAttackIsFinished = true;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animAttackIsFinished)
        {
            GoToTarget();
            colliderAttack.enabled = false;
        }

        if (hasAttacked)
        {
            timer += Time.deltaTime;
            if(timer > coolDownAttack)
            {
                hasAttacked = false;
                timer = 0;
            }
        }


        //float Speed = Vector3.Magnitude(GetComponent<NavMeshAgent>().velocity);
        //GetComponentInChildren<Animator>().SetFloat("Speed", Speed);


        if (navMeshAgent.remainingDistance < distanceAttackPlayer && hasAttacked == false && navMeshAgent.remainingDistance != 0)
        {
            animator.SetTrigger("Attack");
            colliderAttack.enabled = true;
            animAttackIsFinished = false; //repasse à true avec le animAttackBehavior
        }


    }

    private void GoToTarget()
    {
       navMeshAgent.SetDestination(target.position);
    }

    public void Attack(GameObject other)
    {
        if (!hasAttacked)
        {
            other.GetComponent<LifeManager>().ChangeHealth(1);
            hasAttacked = true;
        }
    }

   
}
