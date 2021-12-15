using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;// We need the position of the player so we use "Transform"
    [SerializeField] float chaseRange = 200f;// Set the chase range of the enemy that player should not get closer than that

    NavMeshAgent navMeshAgent; // Select the "NavMeshAgent" and click "ctrl + ." to suggest which library you need to add

    float distanceToTarget = Mathf.Infinity;// At the begginging, the zombie should not think target is close enough

    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if (distanceToTarget <= chaseRange)
        {

            navMeshAgent.SetDestination(target.position);// This way, this game object will set it's destination to the target and follows it
        }
    }

    void OnDrawGizmosSelected()
    {
        //Display chase range of enemy when we select it
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    
}
