using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int speedFactor;
    private GameObject customer;
    private bool free = true;
    private NavMeshAgent agent;
    private Vector3 customerTable;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (free && CustomerManager_3.IsThereCustomer())
        {
            free = false;
            customer = CustomerManager_3.GetCustomer();
            customerTable = customer.GetComponent<customer_3>().GetTable().GetComponent<CustomerTable_3>().GetWaiterPlace().position;
            agent.SetDestination(customerTable);
        }

        if (!free && Vector3.Distance(gameObject.transform.position, customerTable) <= 1.5f)
        {
            WaitToGetOrder(customer.GetComponent<customer_3>().GetTakeOrderTime(),
                customer.GetComponent<customer_3>().GetOrder());
        }
    }

    private IEnumerator WaitToGetOrder(float waitTime, Order_3 customerOrder)
    {
        yield return new WaitForSeconds(waitTime);
        agent.SetDestination(customerOrder.GetFoodTable().GetComponent<FoodTable>().GetWaiterPlace().position);
    }

    private void UpgradeSpeedFactor(int speedFactor)
    {
        this.speedFactor = speedFactor;
    }
    
    
    
}
