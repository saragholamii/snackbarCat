using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SellerMovment : MonoBehaviour
{
    
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void MoveTowards(Vector3 target)
    {
        agent.SetDestination(target);
    }
}
