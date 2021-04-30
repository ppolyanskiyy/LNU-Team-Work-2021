using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] float turnSpeed = 15;
    [SerializeField] Rig aimLayer;

    float waitAfterFire = 2f;
    float timeAfterFire;
    Camera mainCamera;
    float aimDuration = 0.2f;
    RaycastWeapon weapon;

    void Start()
    {
        timeAfterFire = 0f;
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<RaycastWeapon>();
    }
    
    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.deltaTime);
    }
    private void Update()
    {
        if (timeAfterFire > waitAfterFire)
        {
            timeAfterFire = waitAfterFire;
        }
        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
        {
            aimLayer.weight += Time.deltaTime / aimDuration;
        }
        else if (timeAfterFire >= waitAfterFire)
        {
            aimLayer.weight -= Time.deltaTime / aimDuration;
        }

        if (Input.GetMouseButtonDown(0))
        {
            weapon.StartFiring();
        }
        if (weapon.isFiring)
        {
            weapon.UpdateFiring(Time.deltaTime);
        }
        else
        {
            timeAfterFire += Time.deltaTime;
        }
        weapon.UpdateBullets(Time.deltaTime);
        if (Input.GetMouseButtonUp(0))
        {
            timeAfterFire = 0f;
            weapon.StopFiring();
        }
        Debug.Log(timeAfterFire);
    }
}
