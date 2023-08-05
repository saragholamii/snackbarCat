using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerTable_3 : MonoBehaviour
{
    private bool free = true;
    [SerializeField] private List<OrderInfo_3> orders = new List<OrderInfo_3>();
    [SerializeField] private List<customerInfo_3> customers = new List<customerInfo_3>();
    [SerializeField] private Transform enterDoor;
    [SerializeField] private Transform exitDoor;
    [SerializeField] private int minWaitTime;
    [SerializeField] private int maxWaitTime;
    [SerializeField] private Transform waiterPlace;

    void Update()
    {
        if (free)
        {
            free = false;
            WaitAndCreateCustomer(Random.Range(minWaitTime, maxWaitTime));
        }
    }

    //this method will create a customer and an order and set the order for the customer
    private void CreateCustomer()
    {
        int customerIndex = Random.Range(0, customers.Count);
        GameObject customer = Instantiate(customers[customerIndex].customerPrefab, enterDoor.position, Quaternion.identity);
        customer.GetComponent<customer_3>().SetTakeOrderTime(customers[customerIndex].customerTakeOrderTime);
        customer.GetComponent<customer_3>().SetTable(gameObject);
        customer.GetComponent<CustomerMovement_3>().SetTablePos(customers[customerIndex].tablePos);

        int orderIndex = Random.Range(0, orders.Count);
        Order_3 order = new Order_3(orders[orderIndex].orderPref, orders[orderIndex].index, orders[orderIndex].price, orders[orderIndex].waitTime, orders[orderIndex].table);
        customer.GetComponent<customer_3>().SetOrder(order);
    }

    private IEnumerator WaitAndCreateCustomer(int time)
    {
        yield return new WaitForSeconds(time);
        CreateCustomer();
    }

    public Transform GetWaiterPlace()
    {
        return waiterPlace;
    }
}






[Serializable]
public class OrderInfo_3
{
    [SerializeField] public GameObject orderPref;
    [SerializeField] public int index;
    [SerializeField] public int price;
    [SerializeField] public int waitTime;
    [SerializeField] public GameObject table;
}

[Serializable]
public class customerInfo_3
{
    [SerializeField] public GameObject customerPrefab;
    [SerializeField] public int customerTakeOrderTime;
    [SerializeField] public Transform tablePos;
}
