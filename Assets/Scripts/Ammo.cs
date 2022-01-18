using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;// This is the number of bullets 

    //returns number of bullets left
    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    //reduce number of bullets when we shoot
    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }
}
