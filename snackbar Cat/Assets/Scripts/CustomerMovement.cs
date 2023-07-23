using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CustomerMovement : MonoBehaviour
{
    
    private Vector3 tablePos;
    private Vector3 doorPos;
    private NavMeshAgent agent;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y, 0);
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

    public void Exit()
    {
        agent.SetDestination(new Vector3(doorPos.x, doorPos.y, transform.position.z));
    }

    public void SetTablePos(Vector3 tablePos)
    {
        this.tablePos = tablePos;
    }

    public Vector3 GetTablePos()
    {
        return tablePos;
    }

}
