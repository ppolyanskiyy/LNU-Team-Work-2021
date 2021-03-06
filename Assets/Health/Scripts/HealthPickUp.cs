using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private bool playerInSightRange;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] float sightRange;
    [SerializeField] HealthPlayer healthPlayer;
    [SerializeField] GameObject burst;


    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (playerInSightRange)
        {
            RaiseHP();
        }
    }

    public void RaiseHP()
    {
        healthPlayer.RaiseHP(50);
        Instantiate(burst, transform.position, Quaternion.LookRotation(transform.position));
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
