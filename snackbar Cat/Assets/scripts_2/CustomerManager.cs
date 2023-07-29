using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    static List<customer_2> customerList = new List<customer_2>();

    public static void AddCustomer(customer_2 customer)
    {
        customerList.Add(customer);
    }

    public static customer_2 GetCustomer()
    {
        customer_2 customer = customerList[0];
        customerList.RemoveAt(0);
        return customer;
    }

    public static bool ThereIsCustomer()
    {
        return customerList.Count != 0;
    }
}
