using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //we use this to set start position of firing and the diresction
    [SerializeField] Camera FPCamera;
    [SerializeField] float rangeOfShot = 100f;

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
        bool isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward , out hit, rangeOfShot);

        Debug.Log("You hit " + hit.transform.name);
        
    }
}
