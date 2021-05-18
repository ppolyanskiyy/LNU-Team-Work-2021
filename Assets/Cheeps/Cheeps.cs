using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cheeps : MonoBehaviour
{
    private bool playerInSightRange;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] float sightRange;
    [SerializeField] GameObject burst;
    [SerializeField] PlayerCheeps amount;


    void Update()
    {
        Quaternion rotationY = Quaternion.AngleAxis(1, Vector3.up);
        transform.rotation *= rotationY;

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (playerInSightRange)
        {
            TakeCheep();
        }
    }

    public void TakeCheep()
    {
        amount.AmountCheeps();
        Instantiate(burst, transform.position, Quaternion.LookRotation(transform.position));
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
