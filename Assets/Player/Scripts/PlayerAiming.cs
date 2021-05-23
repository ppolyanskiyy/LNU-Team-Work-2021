using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] float turnSpeed = 15;
    [SerializeField] Rig aimLayer;
    [SerializeField] Rig headAimLayer;

    float waitAfterFire = 2f;
    float timeAfterFire;
    Camera mainCamera;
    float aimDuration = 0.2f;

    void Start()
    {
        timeAfterFire = 2f;
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void FixedUpdate()
    {
        if (!Input.GetMouseButton(1))
        {
            float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.deltaTime);
            headAimLayer.weight = 1f;
        }
        else
            headAimLayer.weight = 0f;
    }
    private void LateUpdate()
    {
        if (aimLayer)
        {
            aimLayer.weight = 1.0f;
        }
        //if (timeAfterFire > waitAfterFire)
        //{
        //    timeAfterFire = waitAfterFire;
        //}
        //if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
        //{
        //    aimLayer.weight += Time.deltaTime / aimDuration;
        //}
        //else if (timeAfterFire >= waitAfterFire)
        //{
        //    aimLayer.weight -= Time.deltaTime / aimDuration;
        //}
    }

    //private void LateUpdate()
    //{
    //    if (timeAfterFire > waitAfterFire)
    //    {
    //        timeAfterFire = waitAfterFire;
    //    }
    //    if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
    //    {
    //        aimLayer.weight += Time.deltaTime / aimDuration;
    //    }
    //    else if (timeAfterFire >= waitAfterFire)
    //    {
    //        aimLayer.weight -= Time.deltaTime / aimDuration;
    //    }

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        weapon.StartFiring();
    //    }
    //    if (weapon.isFiring)
    //    {
    //        weapon.UpdateFiring(Time.deltaTime);
    //    }
    //    else
    //    {
    //        timeAfterFire += Time.deltaTime;
    //    }
    //    weapon.UpdateBullets(Time.deltaTime);
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        timeAfterFire = 0f;
    //        weapon.StopFiring();
    //    }
    //}
}
