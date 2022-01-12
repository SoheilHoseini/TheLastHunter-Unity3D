using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHitPoint = 100f;

    public void TakeDamage(float damage)
    {
        playerHitPoint -= damage;
        if(playerHitPoint <= 0)
        {
            Debug.Log("You are getting shot baby!");
        }
    }
}
