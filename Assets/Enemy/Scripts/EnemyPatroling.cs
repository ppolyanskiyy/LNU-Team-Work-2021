using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatroling : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public HealthPlayer health;
    public EnemyActive active;
    public float enemyDamage;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] private float speedEnemie;
    //public float walkPointRange;
    private Vector3 a;
    public float patrolingToPointX;
    public float patrolingToPointZ;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange, damageRange;
    private bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player New").transform;
        agent = GetComponent<NavMeshAgent>();
        a = transform.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer(); 
    }

    private void Patroling()
    {
        agent.Resume();
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            walkPointSet = false;
        }
        animator.SetFloat("VelocityZ", 1f, 0.1f, Time.deltaTime);
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        //float randomZ = Random.Range(centrePatrolingZ - sightRange, centrePatrolingZ + sightRange);
        //float randomX = Random.Range(centrePatrolingX - sightRange, centrePatrolingX + sightRange);
        //walkPoint = new Vector3(randomX, transform.position.y, randomZ);

        if (transform.position.x == patrolingToPointX && patrolingToPointZ == transform.position.z)
        {
            walkPoint = new Vector3(a.x, transform.position.y, a.z);
        }
        else if (transform.position.x == a.x && a.z == transform.position.z)
        {
            walkPoint = new Vector3(patrolingToPointX, transform.position.y, patrolingToPointZ);
        }
        walkPointSet = true;
    }

    private void ChasePlayer()
    {
        active.StopAttack();
        agent.Resume();
        agent.SetDestination(player.position);
        agent.speed = speedEnemie;
        animator.SetFloat("VelocityZ", 1f, 0.1f, Time.deltaTime);
    }

    private void AttackPlayer()
    {

        transform.LookAt(player);
        agent.SetDestination(player.position);
        agent.Stop();
        animator.SetFloat("VelocityZ", 0f, 0.1f, Time.deltaTime);

        active.Fire();
    }
    private void ResetAttack()
    {
        health.playerTakeDamage(enemyDamage);
        alreadyAttacked = false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, damageRange);
    }
}
