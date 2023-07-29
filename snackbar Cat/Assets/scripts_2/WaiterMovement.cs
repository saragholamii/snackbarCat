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
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    void Start()
    {
        animator.Play(IDLE);
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

        //animation:
        currentPosition = transform.position;
        if(Vector3.Distance(currentPosition, previousPosition) <= 0.01f)        ChangeAnimationState(IDLE);
        else  if(currentPosition.y < previousPosition.y)                        ChangeAnimationState(DOWN);
        else                                                                    ChangeAnimationState(UP);
        previousPosition = currentPosition;
    }

    private void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    private void ChangeAnimationState(string newState)
    {
        if(newState == currentState)    return;

        animator.Play(newState);
        currentState = newState;
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
