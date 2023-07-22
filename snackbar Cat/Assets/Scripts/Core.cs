using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{

    private float passedTime = 0f;
    [SerializeField]    private float instantiationTime = 2f;
    [SerializeField]    private Transform customerInstatiatePos;
    [SerializeField]    private GameObject customerPrefab;
    private Datas datas;
    

    void Start() 
    {
        datas = GetComponent<Datas>();    
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
            Vector3 locationOfTable = datas.LocationOfEmptyTable();
            GameObject customer =  Instantiate(customerPrefab, customerInstatiatePos.position, Quaternion.identity);
            customer.GetComponent<CustomerMovement>().SetTablePos(locationOfTable);
        }
    }
}
