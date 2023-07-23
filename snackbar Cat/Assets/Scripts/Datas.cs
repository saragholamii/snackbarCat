using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas : MonoBehaviour
{

    [SerializeField] private GameObject[] tables;
    [SerializeField] private GameObject[] seller;
    [SerializeField] private List<GameObject> OrderPrefabs = new List<GameObject>();

    void Start()
    {
        Debug.Log("order count: " + OrderPrefabs.Count);
    }
    public bool IsThereEmptyTable()
    {
        for(int i = 0; i < tables.Length; i++)
            if(!tables[i].GetComponent<Tables>().full)      return true;
                                                            return false;
    }

    public Vector3 LocationOfEmptyTable()
    {
        for(int i = 0; i < tables.Length; i++)
            if(!tables[i].GetComponent<Tables>().full)
            {
                tables[i].GetComponent<Tables>().SetFull();
                return tables[i].transform.position;
            }
        return new Vector3(0, 0, 0);
    }

    public GameObject GetRandomOrderPrefab()
    {
        GameObject name = OrderPrefabs[Random.Range(0, OrderPrefabs.Count - 1)];
        Debug.Log(name.name);
        return name;
    }

    public void AddOrderPrefab(GameObject newOrderPrefab)
    {
        OrderPrefabs.Add(newOrderPrefab);
    }
}
