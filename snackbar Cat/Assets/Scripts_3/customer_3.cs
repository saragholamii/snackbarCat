using System;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer_3 : MonoBehaviour
{
    [SerializeField] private float takeOrderTime;
    [SerializeField] private float takeOrderTimeFactor;
    [SerializeField] private Order_3 order;
    private GameObject table;

    private void UpgradeWaitTimeFactor(float waitTimeFactor)
    {
        this.takeOrderTimeFactor = takeOrderTimeFactor;
    }

    public void SetTakeOrderTime(int takeOrderTime)
    {
        this.takeOrderTime = takeOrderTime;
    }

    public void SetOrder(Order_3 order)
    {
        this.order = order;
    }

    public Order_3 GetOrder()
    {
        return order;
    }

    public void SetTable(GameObject table)
    {
        this.table = table;
    }

    public GameObject GetTable()
    {
        return table;
    }

    public float GetTakeOrderTime()
    {
        return takeOrderTime;
    }
    
}
