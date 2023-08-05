using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTable : MonoBehaviour
{
    [SerializeField] private int priceFactor;
    [SerializeField] private int waitTimeFactor;
    [SerializeField] private Transform waiterPlace;


    private void Upgrade(int priceFactor, int waitTimeFactor)
    {
        this.priceFactor = priceFactor;
        this.waitTimeFactor = waitTimeFactor;
    }

    public int GetWaitTimeFactor()
    {
        return waitTimeFactor;
    }

    public int GetPriceFactor()
    {
        return priceFactor;
    }

    public Transform GetWaiterPlace()
    {
        return waiterPlace;
    }
}
