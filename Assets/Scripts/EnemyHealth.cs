using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    //returns if the zombie is dead or not
    public bool IsDead()
    {
        return isDead;
    }

    //Take the amount of damage the gun can make and decrease it from enemy health
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");//call a public method on this game object or its children
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead == true) return;// When we shoot a dead zombie, nothing should happen again
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");// When the zombie dies, it goes to die state in animator
    }
}
