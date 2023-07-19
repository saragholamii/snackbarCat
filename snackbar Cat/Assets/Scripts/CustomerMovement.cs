using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CustomerMovement : MonoBehaviour
{
    
    [SerializeField] private GameObject tablePos;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Start()
    {
        GoToTable();
    }

    private void GoToTable()
    {
        agent.SetDestination(new Vector3(tablePos.transform.position.x, tablePos.transform.position.y, transform.position.z));
    }

}
