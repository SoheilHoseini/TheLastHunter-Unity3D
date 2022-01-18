using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();// Choose weapons by keyboard numbers
        ProcessScrollWheel();// Choose weapons by scrolling mouse  wheel

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        //scroll forward
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currentWeapon >= transform.childCount - 1)// this is here to control index of weapons not exceed 2 (number of weapons)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        //scroll backward
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon >= transform.childCount - 1)// this is here to control index of weapons not exceed 2 (number of weapons)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
    }

    private void ProcessKeyInput()
    {
        //when key "1" is pushed, first weapon will be chosen
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        //iterate through all weapons and activate the chosen one
        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
