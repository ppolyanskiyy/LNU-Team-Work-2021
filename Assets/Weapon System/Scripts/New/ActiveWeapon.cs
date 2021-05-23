using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHairTarget;
    public UnityEngine.Animations.Rigging.Rig handIK;
    public Transform weaponParent;
    public Transform weaponLeftHandGrip;
    public Transform weaponRightHandGrip;

    RaycastWeapon weapon;
    Animator animator;
    AnimatorOverrideController overrides;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        overrides = animator.runtimeAnimatorController as AnimatorOverrideController;
        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();
        if (existingWeapon)
        {
            Equip(existingWeapon);
        }
    }
    
    void Update()
    {
        if (weapon)
        {
            if (Input.GetMouseButtonDown(0))
            {
                weapon.StartFiring();
            }
            if (weapon.isFiring)
            {
                weapon.UpdateFiring(Time.deltaTime);
            }
            weapon.UpdateBullets(Time.deltaTime);
            if (Input.GetMouseButtonUp(0))
            {
                weapon.StopFiring();
            }
            handIK.weight = 1.0f;
            animator.SetLayerWeight(1, 1.0f);
        }
        else
        {
            handIK.weight = 0.0f;
            animator.SetLayerWeight(1, 0.0f);
        }
    }

    public void Equip(RaycastWeapon newWeapon)
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
        weapon.transform.parent = weaponParent;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        Invoke(nameof(SetAnimationDelayed), 0.001f);
    }

    void SetAnimationDelayed()
    {
        overrides["empty_anim"] = weapon.weaponAnimation;
    }

    //[ContextMenu("Save weapon pose")] // this attribute means that we can call this function (SaveWeaponPose) from the editor
    //void SaveWeaponPose()
    //{
    //    var recorder = new GameObjectRecorder(gameObject); // gameObject is our character
    //    recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
    //    recorder.BindComponentsOfType<Transform>(weaponLeftHandGrip.gameObject, false);
    //    recorder.BindComponentsOfType<Transform>(weaponRightHandGrip.gameObject, false);
    //    recorder.TakeSnapshot(0.0f);
    //    recorder.SaveToClip(weapon.weaponAnimation);
    //}
}
