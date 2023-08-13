using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager_3 : MonoBehaviour
{
    public static GameManager_3 instance;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject panels;
    [HideInInspector] public UnityEvent<int> checkUpgrade;
    [SerializeField] public UnityEvent<float> increaseWaiterSpeed;
    [SerializeField] private int coins;
   
    
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
        Time.timeScale = 0f;
        panels.SetActive(true);
    }

    public void OnBackToGame()
    {
        Time.timeScale = 1f;
        panels.SetActive(false);
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
    
    public int GetCoins()
    {
        return coins;
    }
    
    
    
}



