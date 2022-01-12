﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();// find the PlayerHealth script
    }

    public void EnemyHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
        Debug.Log("Bang Bang! I shoot you down");
    }

}
