using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovement_3 : MonoBehaviour
{
    [SerializeField] private Transform tablePos;
    private NavMeshAgent agent;
    private bool addedToCustomerManager = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(tablePos.position);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, tablePos.position) <= 1.5f && !addedToCustomerManager)
        {
            CustomerManager_3.AddNewCustomer(gameObject);
            addedToCustomerManager = true;
            CreateOrder();
        }
    }

    public void SetTablePos(Transform tablePos)
    {
        this.tablePos = tablePos;
    }

    private void CreateOrder()
    {
        Transform orderPos = gameObject.transform.GetChild(0);
        Instantiate(gameObject.GetComponent<customer_3>().GetOrder().GetOrderPrefab(), orderPos.position,
            Quaternion.identity);
    }

}
