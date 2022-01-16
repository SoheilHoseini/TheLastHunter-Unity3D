using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    //Take the amount of damage the gun can make and decrease it from enemy health
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");//call a public method on this game object or its children
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
