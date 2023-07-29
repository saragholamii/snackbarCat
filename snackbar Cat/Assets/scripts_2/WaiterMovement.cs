using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaiterMovement : MonoBehaviour
{
    [SerializeField] Transform kitchenTablePos;
    private customer_2 customer;
    private Vector3 customerTablePos;
    private int speed;
    private float waitFactor = 1f;
    private bool free = true;
    private bool orderTaken = false;
    private bool orderMaked = false;
    NavMeshAgent agent;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    
    void Update()
    {
        if(free && CustomerManager.ThereIsCustomer())
        {
            free = false;
            customer = CustomerManager.GetCustomer();
            customerTablePos = customer.GetComponent<CustomerMovment_2>().GetTable().GetComponent<CustomerTable>().GetWaiterPlace();
            MoveTo(customerTablePos);
        }

        if(!free && !orderTaken && Vector3.Distance(transform.position, customerTablePos) <= 2f)
        {
            orderTaken = true;
            StartCoroutine(WaitForOrder(customer.GetComponent<customer_2>().GetOrderWaitTime()));
        }

        if(!free && orderTaken && !orderMaked && Vector3.Distance(transform.position, kitchenTablePos.position) <= 1f)
        {
            orderMaked = true;
            StartCoroutine(WaitForMakeOrder(customer.GetComponent<customer_2>().GetOrder().GetComponent<Food>().GetWaitTime()));
        }

        if(!free && orderTaken && orderMaked && Vector3.Distance(transform.position, customerTablePos) <= 2f)
        {
            DeliverOrder();
        }
    }

    private void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }


    private IEnumerator WaitForOrder(float second)
    {
        yield return new WaitForSeconds(second);
        MoveTo(kitchenTablePos.position);
    }

    private IEnumerator WaitForMakeOrder(float second)
    {
        yield return new WaitForSeconds(second);
        MoveTo(customerTablePos);
    }

    private void DeliverOrder()
    {
        customer.GetComponent<CustomerMovment_2>().MoveOut();
        free = true;
        orderMaked = false;
        orderTaken = false;
    }
}
