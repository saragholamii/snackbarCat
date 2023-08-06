using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order_3
{
    private GameObject orderPrefab;
    private int index;
    private int foodCost;
    private float waitTime;
    private GameObject foodTable;

    public Order_3(GameObject orderPrefab, int index, int foodCost, int waitTime, GameObject foodTable)
    {
        this.orderPrefab = orderPrefab;
        this.index = index;
        this.foodCost = foodCost;
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

    public float GetWaitTime()
    {
        return waitTime;
    }

    public int GetFoodCost()
    {
        return foodCost;
    }
}
