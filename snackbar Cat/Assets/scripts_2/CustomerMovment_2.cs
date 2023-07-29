using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovment_2 : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform exitDoor;
    private GameObject table;
    private GameObject order;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Start() 
    {
        CustomerManager.AddCustomer(this.gameObject.GetComponent<customer_2>());
        MoveIn();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, table.GetComponent<CustomerTable>().GetCustomerPlace()) <= 1f)        CreateOrder();
    }

    private void MoveIn()
    {
        agent.SetDestination(table.GetComponent<CustomerTable>().GetCustomerPlace());
    }

    public void CreateOrder()
    {
        order = Instantiate(this.gameObject.GetComponent<customer_2>().GetOrder(), transform.GetChild(0).position, Quaternion.identity);
    }

    public void SetTable(GameObject table)
    {
        agent = GetComponent<NavMeshAgent>();
        this.table = table;
    }

    public void MoveOut()
    {
        Destroy(order);
        table.GetComponent<CustomerTable>().SetFree();
        agent.SetDestination(exitDoor.position);
    }

    public void SetExitDoor(Transform exitDoor)
    {
        this.exitDoor = exitDoor;
    }

    public GameObject GetTable()
    {
        return table;
    }
}
