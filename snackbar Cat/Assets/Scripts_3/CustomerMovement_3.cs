using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMovement_3 : MonoBehaviour
{
    [SerializeField] private Transform tablePos;
    private NavMeshAgent agent;
    private bool addedToCustomerManager = false;
    private Vector3 exitDoor;
    private GameObject orderRequest;
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

        if (Vector3.Distance(transform.position, exitDoor) <= 2f)
        {
            Destroy(gameObject);
        }
        
        //animation:
        currentPosition = transform.position;
        if(Vector3.Distance(currentPosition, previousPosition) <= 0.01f)        ChangeAnimationState(IDLE);
        else  if(currentPosition.y < previousPosition.y)                        ChangeAnimationState(DOWN);
        else                                                                    ChangeAnimationState(UP);
        previousPosition = currentPosition;
    }
    
    private void ChangeAnimationState(string newState)
    {
        if(newState == currentState)    return;

        animator.Play(newState);
        currentState = newState;
    }
    
    private void CreateOrder()
    {
        Transform orderPos = gameObject.transform.GetChild(0);
        orderRequest = Instantiate(gameObject.GetComponent<customer_3>().GetOrder().GetOrderPrefab(), orderPos.position,
            Quaternion.identity);
    }

    public void SetTablePos(Transform tablePos)
    {
        this.tablePos = tablePos;
    }
    
    public void OrderDelivered()
    {
        gameObject.GetComponent<customer_3>().Pay();
        Destroy(orderRequest);
        gameObject.GetComponent<customer_3>().FreeCustomerTable();
        exitDoor = gameObject.GetComponent<customer_3>().GetTable().GetComponent<CustomerTable_3>()
            .GetExitDoor().position;
        agent.SetDestination(exitDoor);
    }
    

}
