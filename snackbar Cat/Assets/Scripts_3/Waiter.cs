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
    private bool TakingOrder = false;
    private bool MakingOrder = false;
    private NavMeshAgent agent;
    private Vector3 customerTable;
    private Animator animator;
    private string currentState;
    private Vector3 currentPosition;
    private Vector3 previousPosition;
    
    //animation states:
    const string IDLE = "IDLE";
    const string DOWN = "Forward";
    const string UP = "Back";

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(IDLE);
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

        if (!free && !TakingOrder && Vector3.Distance(gameObject.transform.position, customerTable) <= 1.5f)
        {
            TakingOrder = true;
            StartCoroutine(WaitToGetOrder(customer.GetComponent<customer_3>().GetTakeOrderTime(),
                customer.GetComponent<customer_3>().GetOrder()));
        }

        if (!free && TakingOrder && !MakingOrder && Vector3.Distance(gameObject.transform.position,
                customer.GetComponent<customer_3>().GetOrder().GetFoodTable().GetComponent<FoodTable>().GetWaiterPlace()
                    .position) <= 1.5f)
        {
            MakingOrder = true;
            StartCoroutine(WiatToBakeTheOrder(customer.GetComponent<customer_3>().GetOrder().GetWaitTime()));
        }

        if (!free && TakingOrder && MakingOrder &&
            Vector3.Distance(gameObject.transform.position, customerTable) <= 1.5f)
        {
            free = true;
            TakingOrder = false;
            MakingOrder = false;
            customer.GetComponent<CustomerMovement_3>().OrderDelivered();
        }
        
        //animation:
        currentPosition = transform.position;
        if(Vector3.Distance(currentPosition, previousPosition) <= 0.01f)        ChangeAnimationState(IDLE);
        else  if(currentPosition.y < previousPosition.y)                        ChangeAnimationState(DOWN);
        else                                                                    ChangeAnimationState(UP);
        previousPosition = currentPosition;
    }

    private IEnumerator WaitToGetOrder(float waitTime, Order_3 customerOrder)
    {
        yield return new WaitForSeconds(waitTime);
        agent.SetDestination(customerOrder.GetFoodTable().GetComponent<FoodTable>().GetWaiterPlace().position);
    }

    private IEnumerator WiatToBakeTheOrder(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        agent.SetDestination(customerTable);
    }
    
    private void ChangeAnimationState(string newState)
    {
        if(newState == currentState)    return;

        animator.Play(newState);
        currentState = newState;
    }

    private void UpgradeSpeedFactor(int speedFactor)
    {
        this.speedFactor = speedFactor;
        agent.speed = speed * speedFactor;
    }
    
    
    
}
