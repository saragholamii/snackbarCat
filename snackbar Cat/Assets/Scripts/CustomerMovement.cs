using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CustomerMovement : MonoBehaviour
{
    
    private Vector3 tablePos;
    private Vector3 doorPos;
    private NavMeshAgent agent;
    private bool orderDelivered = false;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Start()
    {
        GoTo();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, doorPos) < 1.5f && orderDelivered)       Destroy(this.gameObject);
    }

    public void GoTo()
    {
        agent.SetDestination(new Vector3(tablePos.x, tablePos.y, transform.position.z));
    }

    public void Exit()
    {
        orderDelivered = true;
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

    public void SetDoorPos(Vector3 doorPos)
    {
        this.doorPos = doorPos;
    }

}
