using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    //I think ammo slot is a holder of bullet and other ammo types like a backpack
    [System.Serializable]//this will show the private class contents in the inspector
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;// This is the number of bullets 
    }

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
