using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order_3
{
    private GameObject orderPrefab;
    private int index;
    private int price;
    private int waitTime;
    private GameObject foodTable;

    public Order_3(GameObject orderPrefab, int index, int price, int waitTime, GameObject foodTable)
    {
        this.orderPrefab = orderPrefab;
        this.index = index;
        this.price = price;
        this.waitTime = waitTime;
        this.foodTable = foodTable;
    }

    public GameObject GetOrderPrefab()
    {
        return orderPrefab;
    }

    public GameObject GetFoodTable()
    {
        return foodTable;
    }
}
