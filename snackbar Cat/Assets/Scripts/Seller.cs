using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    private List<Customer> customersList;

    public void AddCustomer(Customer c)
    {
        customersList.Add(c);
    }
}
