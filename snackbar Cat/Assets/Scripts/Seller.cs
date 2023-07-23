using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    [SerializeField] private float distanceFromTable = 6f;
    [SerializeField] private float takingOrderTime = 2f;
    [SerializeField] private float makingOrderTime = 4f;
    [SerializeField] private Transform kitchenTablePos;
    private List<Customer> customersList = new List<Customer>();
    private bool busy = false;
    private bool takingOrder = false;
    private bool makingOrder = false;
    private bool deliveringOrder = false;
    private SellerMovment sellerMovment;
    private Vector3 customerPos;
    private GameObject newCustomer;
    private GameObject customerOrderWithPlatePrefab;


    void Start()
    {
        sellerMovment = GetComponent<SellerMovment>();
    }

    void Update() 
    {
        if(customersList.Count != 0 && !busy)           TakeOrder();
        if(Vector3.Distance(transform.position, customerPos) <= 1.5 && busy && !takingOrder)         WaitForOrder();
        if(Vector3.Distance(transform.position, kitchenTablePos.position) <= 1.5f && busy && takingOrder && !makingOrder)        MakeOrder();
        if(Vector3.Distance(transform.position, customerPos) <= 1.5 && busy && takingOrder && makingOrder && !deliveringOrder)          DeliverOrder();
    }

    private void TakeOrder()
    {
        busy = true;
        newCustomer = customersList[0].gameObject;
        customersList.RemoveAt(0);
        customerPos = new Vector3(newCustomer.transform.position.x, newCustomer.transform.position.y - distanceFromTable, newCustomer.transform.position.z);
        sellerMovment.MoveTowards(customerPos);
    }

    private void WaitForOrder()
    {
        takingOrder = true;
        StartCoroutine(WaitForOrderCoroutin(takingOrderTime));
    }

    private void MakeOrder()
    {
        makingOrder = true;
        StartCoroutine(WaitForMakeOrderCoroutin(makingOrderTime));
    }

    private void DeliverOrder()
    {
        newCustomer.GetComponent<Customer>().OrderDelivered();
        busy = false;
        takingOrder = false;
        makingOrder = false;
        deliveringOrder = false;
    }

    private IEnumerator WaitForOrderCoroutin(float sec)
    {
        yield return new WaitForSeconds(sec);
        sellerMovment.MoveTowards(kitchenTablePos.position);
    }

    private IEnumerator WaitForMakeOrderCoroutin(float sec)
    {
        yield return new WaitForSeconds(sec);
        sellerMovment.MoveTowards(customerPos);
    }

    public void AddCustomer(Customer c)
    {
        customersList.Add(c);
    }

    public void SetCustomerOrderPrefab(GameObject orderPrefab)
    {
        customerOrderWithPlatePrefab = orderPrefab;
    }
}
