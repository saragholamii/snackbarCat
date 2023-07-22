using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CustomerMovement : MonoBehaviour
{
    
    private Vector3 tablePos;
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
        agent.SetDestination(new Vector3(tablePos.x, tablePos.y, transform.position.z));
    }

    public void SetTablePos(Vector3 tablePos)
    {
        this.tablePos = tablePos;
    }

}
