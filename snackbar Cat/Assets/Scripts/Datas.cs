using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas : MonoBehaviour
{

    [SerializeField] private GameObject[] tables;
    [SerializeField] private List<GameObject> sellers = new List<GameObject>();
    [SerializeField] private List<GameObject> orderPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> orderWithPlatePrefab = new List<GameObject>();
    [SerializeField] private List<GameObject> coins = new List<GameObject>();
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
        return (sellers[(nextSeller++ % sellers.Count)]);
    }

    public GameObject[] GetRandomOrderPrefab()
    {
        int index = Random.Range(0, orderPrefabs.Count - 1);
        GameObject[] order = {orderPrefabs[index], coins[index]};
        return order;
    }

    public void AddOrderPrefab(GameObject newOrderPrefab)
    {
        orderPrefabs.Add(newOrderPrefab);
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
}
