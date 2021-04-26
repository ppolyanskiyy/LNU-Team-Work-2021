using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime;
 

    //some bools
    bool shooting, readyToShoot, reloading;

    public Transform enemy;
    public Transform attackPos;
    public GameObject muzzleFlash;
    public RaycastHit rayHit;
    public LayerMask whatIsPlayer;

    private void Start()
    {
        readyToShoot = true;
    }

    private void Update()
    {
        shooting = true;//enemy.GetComponent<ShootingAi>().isAttacking;
        if (shooting) Shoot();
    }

    public void Shoot()
    {


        readyToShoot = false;
       /* if (Physics.Raycast(transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.enemiesTakeDamage(damage);
            }

            Instantiate(muzzleFlash, attackPos.position, Quaternion.identity);
            Invoke("ShotReset", timeBetweenShooting);
        }*/
    }
    private void ShotReset()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;

        Invoke("ReloadingFinished", reloadTime);
    }
    private void ReloadingFinished()
    {
        reloading = false;
    }
}
