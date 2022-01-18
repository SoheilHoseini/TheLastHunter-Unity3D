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
        public int ammoAmount;// This is the number of bullets and is set in the inspector
    }

    //returns number of bullets left
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    //reduce number of bullets when we shoot
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    //return the ammo slot information that we are looking for
    private AmmoSlot GetAmmoSlot(AmmoType myAmmoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == myAmmoType)
            {
                return slot;
            }
        }

        return null;//to fix return type error
    }
}
