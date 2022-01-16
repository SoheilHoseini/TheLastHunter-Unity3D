using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    //Take the amount of damage the gun can make and decrease it from enemy health
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Debug.Log("You have been shot baby!");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
