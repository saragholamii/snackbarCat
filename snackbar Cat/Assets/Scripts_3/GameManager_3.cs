using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager_3 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private int coins;
    [HideInInspector] public UnityEvent<int> checkUpgrade;
    public static GameManager_3 instance;
    private void Start()
    {
        instance = this;
    }

    public void OnPay(int changes)
    {
        coins += changes;
        coinText.text = coins.ToString();
        checkUpgrade.Invoke(coins);
    }
    
    
    
}
