using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUpgradeBuyButton : MonoBehaviour
{
    [SerializeField] private int cost;

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
        gameObject.GetComponent<Button>().interactable = true;
    }

    public void UpgradeUnAvailable()
    {
        Color currentColor = gameObject.GetComponent<Image>().color;
        currentColor.a = 0.5f;
        gameObject.GetComponent<Image>().color = currentColor;
        gameObject.GetComponent<Button>().interactable = false;
    }
    
    
}
