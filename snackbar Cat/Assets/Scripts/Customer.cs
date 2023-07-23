using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    private GameObject orderPrefab;
    private Vector3 tablePos;
    GameObject Order;
    private bool orderCreated1 = false;
    private bool orderCreated2 = false;
    private Rigidbody2D rb;
    private NavMeshAgent agent;

    void Start()
    {
        tablePos = GetComponent<CustomerMovement>().GetTablePos();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody2D>();
        //transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Debug.Log("table pos: " + tablePos);
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, tablePos) < 1.5f && !orderCreated1)
        {
            CreateOrder();
            orderCreated1 = true;
        }
    }

    public void CreateOrder()
    {
        Debug.Log("inside create Order");
        Vector3 OrderPos = transform.GetChild(0).position;
        Order = Instantiate(orderPrefab, OrderPos, Quaternion.identity);
    }

    public void SetOrderPrefab(GameObject orderPrefab)
    {
        this.orderPrefab = orderPrefab;
    }

    public void OrderDelivered()
    {
        Destroy(Order);
    }
}
