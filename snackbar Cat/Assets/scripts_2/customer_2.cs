using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class customer_2 : MonoBehaviour
{
    private GameObject order;
    [SerializeField] private float orderWaitTime;
    
    public void SetOrder(GameObject order)
    {
        this.order = order;
    }

    public GameObject GetOrder()
    {
        return order;
    }

    public float GetOrderWaitTime()
    {
        return orderWaitTime;
    }
}
