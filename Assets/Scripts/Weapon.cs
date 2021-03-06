using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    //we use this to set start position of firing and the diresction
    [SerializeField] Camera FPCamera;
    [SerializeField] float rangeOfShot = 100f;
    [SerializeField] float damageAmount = 20f;
    [SerializeField] ParticleSystem muzzleFlash;//particle effect for shooting with the gun
    [SerializeField] GameObject hitEffect;// we use GameObject to be able to destroy it (instead of ParticleSystem)
    
    [SerializeField] Ammo ammoSlot; // How much ammo we have
    [SerializeField] AmmoType ammoType; // Bullets, Shells or Rockets?!    :)

    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI bulletText;
    [SerializeField] TextMeshProUGUI shellText;
    [SerializeField] TextMeshProUGUI rocketText;

    bool canShoot = true;

    [SerializeField] AudioSource gunShotSFX;

    private void OnEnable()
    {
        canShoot = true;// this is to fix the bug that switching between weapons, might disable shooting for the new one
    }
    void Update()
    {
        //Display ammo in screen
        if (ammoType == AmmoType.Bullets)
            DisplayBullets();

        else if (ammoType == AmmoType.Rockets)
            DisplayRockets();

        else if (ammoType == AmmoType.Shells)
            DisplayShells();


        if(Input.GetButtonDown("Fire1") && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }
    
    //Shells
    private void DisplayShells()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        shellText.text = "Shells: " + currentAmmo.ToString();
    }

    //Rockets
    private void DisplayRockets()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        rocketText.text = "Rockets: " + currentAmmo.ToString();
    }

    //Bullets
    private void DisplayBullets()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        bulletText.text = "Bullets: " + currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {

        canShoot = false;

        //player only can shoot we he has ammo left
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();//Plays a VFX when shooting
            ProcessRaycasting();
            ammoSlot.ReduceCurrentAmmo(ammoType);// reduce bullets when we shoot
            gunShotSFX.Play();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
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
