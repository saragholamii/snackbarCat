using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas : MonoBehaviour
{

    [SerializeField] private GameObject[] tables;
    [SerializeField] private List<GameObject> sellers = new List<GameObject>();
    [SerializeField] private List<GameObject> orderPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> orderWithPlatePrefab = new List<GameObject>();
    private int nextSeller = 0;


    public bool IsThereEmptyTable()
    {
        for(int i = 0; i < tables.Length; i++)
            if(!tables[i].GetComponent<Tables>().full)      return true;
                                                            return false;
    }

    public GameObject LocationOfEmptyTable()
    {
        for(int i = 0; i < tables.Length; i++)
            if(!tables[i].GetComponent<Tables>().full)
            {
                tables[i].GetComponent<Tables>().SetFull();
                return tables[i];
            }
        return null;
    }

    public GameObject GetSeller()
    {
        return (sellers[(nextSeller++ % sellers.Count)]);
    }

    public GameObject GetRandomOrderPrefab()
    {
        GameObject name = orderPrefabs[Random.Range(0, orderPrefabs.Count - 1)];
        Debug.Log(name.name);
        return name;
    }

    public void AddOrderPrefab(GameObject newOrderPrefab)
    {
        orderPrefabs.Add(newOrderPrefab);
    }
}
