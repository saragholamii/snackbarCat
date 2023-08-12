using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager_3 : MonoBehaviour
{
    public static GameManager_3 instance;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private int coins;
    [HideInInspector] public UnityEvent<int> checkUpgrade;
    [SerializeField] public UnityEvent<float> increaseWaiterSpeed;
    private void Awake()
    {
        instance = this;
    }

    public void OnPay(int changes)
    {
        coins += changes;
        coinText.text = coins.ToString();
        checkUpgrade.Invoke(coins);
    }

    public void OnClickGeneralUpgradeButton()
    {
        //the game should stop, a page should appear to show the upgrade options
    }

    public void OnBuyWaiterSpeed(float factor)
    {
        //decrease the money
        increaseWaiterSpeed.Invoke(factor);
    }

    public void OnBuyNewAssistant()
    {
        //decrease the money
        //create another waiter
    }
    
    
    
}
