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
    private bool ordered = false;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Start() 
    {
        MoveIn();
        Debug.Log("table.GetComponent<CustomerTable>().GetCustomerPlace(): " + table.GetComponent<CustomerTable>().GetCustomerPlace());
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, table.GetComponent<CustomerTable>().GetCustomerPlace()) <= 2f && !ordered)
        {
            ordered = true;
            CustomerManager.AddCustomer(this.gameObject.GetComponent<customer_2>());
            CreateOrder();
        }    

        if(Vector3.Distance(transform.position, exitDoor.position) <= 2f)    
        {
            Destroy(gameObject);
        }
    }

    private void MoveIn()
    {
        agent.SetDestination(table.GetComponent<CustomerTable>().GetCustomerPlace());
    }

    public void CreateOrder()
    {
        order = Instantiate(gameObject.GetComponent<customer_2>().GetOrder(), transform.GetChild(0).position, Quaternion.identity);
    }

    public void SetTable(GameObject table)
    {
        agent = GetComponent<NavMeshAgent>();
        this.table = table;
    }

    public void MoveOut()
    {
        Debug.Log("inside moveout");
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
