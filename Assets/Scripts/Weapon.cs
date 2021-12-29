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

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //Calculate the fire info
        RaycastHit hit;//information of our ray, colliding with any object
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward , out hit, rangeOfShot))
        {
            Debug.Log("You hit " + hit.transform.name);
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
}
