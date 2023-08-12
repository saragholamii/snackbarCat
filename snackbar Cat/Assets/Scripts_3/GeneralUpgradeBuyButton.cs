using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUpgradeBuyButton : MonoBehaviour
{
    [SerializeField] private int cost;
    private Button thisButton;

    private void Start()
    {
        thisButton = GetComponent<Button>();
        GameManager_3.instance.checkUpgrade.AddListener(CheckUpgrade);
    }

    public void SetCost(int cost)
    {
        this.cost = cost;
    }

    public void CheckUpgrade(int coins)
    {
        if (coins >= cost) UpgradeAvailable();
        else               UpgradeUnAvailable();
    }

    public void UpgradeAvailable()
    {
        Color currentColor = gameObject.GetComponent<Image>().color;
        currentColor.a = 1f;
        gameObject.GetComponent<Image>().color = currentColor;
        thisButton.interactable = true;
    }

    public void UpgradeUnAvailable()
    {
        Color currentColor = gameObject.GetComponent<Image>().color;
        currentColor.a = 0.5f;
        gameObject.GetComponent<Image>().color = currentColor;
        thisButton.interactable = true;
    }
    
    
}
