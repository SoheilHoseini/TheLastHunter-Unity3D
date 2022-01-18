using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //we use this to set start position of firing and the diresction
    [SerializeField] Camera FPCamera;
    [SerializeField] float rangeOfShot = 100f;
    [SerializeField] float damageAmount = 20f;
    [SerializeField] ParticleSystem muzzleFlash;//particle effect for shooting with the gun
    [SerializeField] GameObject hitEffect;// we use GameObject to be able to destroy it (instead of ParticleSystem)
    [SerializeField] Ammo ammoSlot; // How much ammo we have

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        //player only can shoot we he has ammo left
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();//Plays a VFX when shooting
            ProcessRaycasting();
            ammoSlot.ReduceCurrentAmmo();// reduce bullets when we shoot
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycasting()
    {
        //Calculate the fire info
        RaycastHit hit;//information of our ray, colliding with any object
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, rangeOfShot))
        {
            CreateHitImpact(hit);
            //To Do: add some hit effects for visual players

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            //call a method on EnemyHealth that decreases enemy health
            if (target == null) return; //This way if we hit sth other than enemy, will not get NullReference error
            target.TakeDamage(damageAmount);
        }
        else
        {
            //To avoid NullReference when shooting the sky
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        //Instantiate hit effects at the position when the bullets hit
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);//destroy the hit effect 1 sec after it's been instantiated
    }
}
