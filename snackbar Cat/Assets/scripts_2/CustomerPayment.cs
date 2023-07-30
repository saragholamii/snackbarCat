using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomerPayment : MonoBehaviour
{
    [SerializeField] private UnityEvent onPay;

    public void pay()
    {
        onPay?.Invoke();
    }
}
