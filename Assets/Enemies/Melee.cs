using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Melee : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public HealthPlayer health;
    public float enemyDamage;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;

    //public float walkPointRange;
    private Vector3 position;
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
        //player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        position = transform.position;
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
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            walkPointSet = false;
        }

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        //float randomZ = Random.Range(centrePatrolingZ - sightRange, centrePatrolingZ + sightRange);
        //float randomX = Random.Range(centrePatrolingX - sightRange, centrePatrolingX + sightRange);
        //walkPoint = new Vector3(randomX, transform.position.y, randomZ);

        if (transform.position.x == patrolingToPointX && patrolingToPointZ == transform.position.z)
        {
            walkPoint = new Vector3(position.x, transform.position.y, position.z);
        }
        else if (transform.position.x == position.x && position.z == transform.position.z)
        {
            walkPoint = new Vector3(patrolingToPointX, transform.position.y, patrolingToPointZ);
        }
        walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(player.position);

        transform.LookAt(player);

        if (!alreadyAttacked && Physics.CheckSphere(transform.position, damageRange, whatIsPlayer))
        {
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
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


