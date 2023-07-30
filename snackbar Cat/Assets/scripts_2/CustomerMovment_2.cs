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
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Start() 
    {
        MoveIn();
        animator.Play(DOWN);
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


        //animation:
        currentPosition = transform.position;
        if(Vector3.Distance(currentPosition, previousPosition) <= 0.01f)        ChangeAnimationState(IDLE);
        else  if(currentPosition.y < previousPosition.y)                        ChangeAnimationState(DOWN);
        else                                                                    ChangeAnimationState(UP);
        previousPosition = currentPosition;

    }

    private void MoveIn()
    {
        agent.SetDestination(table.GetComponent<CustomerTable>().GetCustomerPlace());
    }

    public void CreateOrder()
    {
        order = Instantiate(gameObject.GetComponent<customer_2>().GetOrder(), transform.GetChild(0).position, Quaternion.identity);
    }

    private void ChangeAnimationState(string newState)
    {
        if(newState == currentState)    return;

        animator.Play(newState);
        currentState = newState;
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
