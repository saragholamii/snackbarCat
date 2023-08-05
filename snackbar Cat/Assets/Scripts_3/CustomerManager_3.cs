using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager_3 : MonoBehaviour
{
    private static List<GameObject> customersList = new List<GameObject>();

    public static void AddNewCustomer(GameObject newCustomer)
    {
        customersList.Add(newCustomer);
    }

    public static GameObject GetCustomer()
    {
        GameObject customer = customersList[0];
        customersList.RemoveAt(0);
        return customer;
    }

    public static bool IsThereCustomer()
    {
        if (customersList.Count != 0) return true;
        return false;
    }
}
