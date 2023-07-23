using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    private GameObject orderPrefab;
    private Vector3 tablePos;
    private GameObject table;
    GameObject Order;
    private bool orderCreated = false;
    private Rigidbody2D rb;
    private NavMeshAgent agent;
    private CustomerMovement customerMovement;

    void Start()
    {
        customerMovement = GetComponent<CustomerMovement>();
        tablePos = customerMovement.GetTablePos();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, tablePos) < 1.5f && !orderCreated)
        {
            CreateOrder();
            Core.newCustomer(this.gameObject);
            orderCreated = true;
        }
    }

    public void CreateOrder()
    {
        Vector3 OrderPos = transform.GetChild(0).position;
        Order = Instantiate(orderPrefab, OrderPos, Quaternion.identity);
    }

    public void SetOrderPrefab(GameObject orderPrefab)
    {
        this.orderPrefab = orderPrefab;
    }

    public void SetTable(GameObject table)
    {
        this.table = table;
    }

    public void OrderDelivered()
    {
        Destroy(Order);
        Core.releaseTable(table);
        customerMovement.Exit();
    }
}
