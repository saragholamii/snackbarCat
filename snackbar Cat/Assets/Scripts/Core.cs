using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{

    private float passedTime = 0f;
    [SerializeField]    private float instantiationTime = 2f;
    [SerializeField]    private Transform doorPos;
    [SerializeField]    private GameObject customerPrefab;
    private Datas datas;
    public delegate void NewCustomer(GameObject customer);
    public static NewCustomer newCustomer;
    public delegate void ReleaseTable(GameObject table, GameObject coin);
    public static ReleaseTable releaseTable;
    

    void Start() 
    {
        datas = GetComponent<Datas>();
        newCustomer += AddCustomerToSellerList;
        releaseTable += Release_Table;
    }

    void Update()
    {
        passedTime += Time.deltaTime;
        if(passedTime >= instantiationTime)
        {
            CreateCustomer();
            passedTime = 0f;
        }
    }

    private void CreateCustomer()
    {
        if(datas.IsThereEmptyTable())
        {
            GameObject table = datas.LocationOfEmptyTable();
            Vector3 locationOfTable = table.transform.position;
            GameObject customer =  Instantiate(customerPrefab, doorPos.position, Quaternion.identity);
            GameObject[] order = datas.GetRandomOrderPrefab();
            customer.GetComponent<CustomerMovement>().SetTablePos(locationOfTable);
            customer.GetComponent<CustomerMovement>().SetDoorPos(doorPos.position);
            customer.GetComponent<Customer>().SetTable(table);
            customer.GetComponent<Customer>().SetOrderPrefab(order[0]);
            customer.GetComponent<Customer>().SetCoin(order[1]);
        }
    }

    private void AddCustomerToSellerList(GameObject customer)
    {
        GameObject seller = datas.GetSeller();
        seller.GetComponent<Seller>().AddCustomer(customer.GetComponent<Customer>());
    }

    private void Release_Table(GameObject table, GameObject coin)
    {
        Instantiate(coin, new Vector3(table.transform.position.x, table.transform.position.y - 1, table.transform.position.z), Quaternion.identity);
        table.GetComponent<Tables>().SetEmpty();
    }
}
