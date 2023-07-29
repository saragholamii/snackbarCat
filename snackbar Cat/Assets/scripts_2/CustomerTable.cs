using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTable : MonoBehaviour
{

    [SerializeField] List<GameObject> orderPrefabs = new List<GameObject>();
    [SerializeField] List<GameObject> customersPrefab = new List<GameObject>();
    [SerializeField] Transform enterDoor;
    [SerializeField] Transform exitDoor;
    [SerializeField] Transform customerPlace;
    [SerializeField] Transform waiterPlace;
    private bool free = true;
    

    void Update()
    {
        if(free)
        {
            Debug.Log("free");
            free = false;
            StartCoroutine(WaitAndCreate(Random.Range(2, 5)));
        }   
    }

    private IEnumerator WaitAndCreate(int second)
    {
        Debug.Log("second: " + second);
        yield return new WaitForSeconds(second);
        CreateCustomer();
    }

    private void CreateCustomer()
    {
        Debug.Log("inside create customer");
        GameObject customer = Instantiate(customersPrefab[Random.Range(0, customersPrefab.Count)], enterDoor.position, Quaternion.identity);
        customer.GetComponent<CustomerMovment_2>().SetTable(this.gameObject);
        customer.GetComponent<CustomerMovment_2>().SetExitDoor(exitDoor);
        customer.GetComponent<customer_2>().SetOrder(orderPrefabs[Random.Range(0, orderPrefabs.Count)]);
    }

    //it's a little bit upper than the table
    public Vector3 GetCustomerPlace()
    {
        return customerPlace.position;
    }

    public Vector3 GetWaiterPlace()
    {
        return waiterPlace.position;
    }

    public void SetFree()
    {
        free = true;
    }
}
