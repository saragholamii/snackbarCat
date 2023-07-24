using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas : MonoBehaviour
{

    [SerializeField] private GameObject[] tables;
    [SerializeField] private List<GameObject> orderPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> orderWithPlatePrefab = new List<GameObject>();
    [SerializeField] private List<GameObject> kitchenTables = new List<GameObject>();
    private List<GameObject> sellers = new List<GameObject>();
    private static int score = 0;
    private static int price = 1;
    private static int level = 1;
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
        if(sellers.Count == 1)                                                                                                   return sellers[0];
        else if(sellers[0].GetComponent<Seller>().GetCustomerNum() >= sellers[1].GetComponent<Seller>().GetCustomerNum())        return sellers[1];
        else                                                                                                                     return sellers[0];
    }

    public GameObject GetRandomOrderPrefab()
    {
        int index = Random.Range(0, orderPrefabs.Count - 1);
        GameObject order = orderPrefabs[index];
        return order;
    }

    public void AddOrderPrefab(GameObject newOrderPrefab)
    {
        orderPrefabs.Add(newOrderPrefab);
    }

    public void AddNewSeller(GameObject newSeller)
    {
        sellers.Add(newSeller);
    }

    public static void IncreaseScore(int amount)
    {
        score += amount;
        Core.updateScore(score);
    }

    public static void DecreaseScore(int amount)
    {
        score -= amount;
        Core.updateScore(score);
    }

    public static int GetScore()
    {
        return score;
    }

    public static void SetNewPrice(int newPrice)
    {
        price = newPrice;
        Core.updatePrice(price);
    }

    public static int GetPrice()
    {
        Debug.Log("price: " + price);
        return price;
    }

    public static int GetLevel()
    {
        return level;
    }

    public static void SetLevel(int newLevel)
    {
        level = newLevel;
        Core.updateLevel(level);
    }

    public Vector3 GetKitchenTablePos(int sellerNum)
    {
        return kitchenTables[sellerNum].transform.position;
    }
}
