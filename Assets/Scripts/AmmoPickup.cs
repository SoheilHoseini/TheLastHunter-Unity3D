using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //when the player collides with the ammo, he takes it
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("You picked up ammo!");
            Destroy(gameObject);// destroy the ammo when it is picked
        }
    }
}
