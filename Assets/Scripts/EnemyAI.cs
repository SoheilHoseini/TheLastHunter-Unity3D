using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;// We need the position of the player so we use "Transform"
    NavMeshAgent navMeshAgent; // Select the "NavMeshAgent" and click "ctrl + ." to suggest which library you need to add

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.position);// This way, this game object will set it's destination to the target and follows it
    }
}
