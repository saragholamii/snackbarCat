using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodTable : MonoBehaviour
{
    //[SerializeField] private GameObject GameManager;
    [SerializeField] private int level = 1;
    [SerializeField] private float waitTimeFactor = 0;
    [SerializeField] private int foodCostIncreasment = 0;
    [SerializeField] private List<UpgradeInfo_3> upgradeConditions = new List<UpgradeInfo_3>();
    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject upgradeMessage;
    [SerializeField] private TextMeshProUGUI upgradMessageText;
    private UpgradeInfo_3 currentUpgradeInfo
    {
        get
        { 
            if (level > upgradeConditions.Count) return new UpgradeInfo_3(int.MaxValue, 100);
            return upgradeConditions[level - 1];
        }
    }

    void Start()
    {
        GameManager_3.instance.checkUpgrade.AddListener(CheckUpgrade);
    }

    public float GetWaitTimeFactor()
    {
        return waitTimeFactor;
    }

    public int GetFoodCostIncreasment()
    {
        return foodCostIncreasment;
    }

    public Transform GetWaiterPlace()
    {
        return transform;
    }

    //************* upgrade methods *****************
    //this method will call on any coin change, to check the upgrade conditions
    public void CheckUpgrade(int coins)
    {
        if (coins >= currentUpgradeInfo.cost && level < upgradeConditions.Count) UpgradeAvailabe();
        else UpgradeNotAvailable();
    }

    private void UpgradeAvailabe()
    {
        upgradeButton.SetActive(true);
    }

    private void UpgradeNotAvailable()
    {
        upgradeButton.SetActive(false);
        upgradeMessage.SetActive(false);
    }

    public void OnClickUpgradeButton()
    {
        upgradeButton.SetActive(false);
        upgradMessageText.text =
            $"for {currentUpgradeInfo.cost} coins, the cost of food increases {currentUpgradeInfo.foodCostIncreasment} coin(s) " +
            $"and cooking time decreases {currentUpgradeInfo.WaitTimeFactor} percent";
        upgradeMessage.SetActive(true);
    }
    
    //*********** upgrade button methods ***********
    public void OnAcceptUpgrade()
    {
        upgradeMessage.SetActive(false);
        Upgrade();
    }

    public void OnRejectUpgrade()
    {
        upgradeMessage.SetActive(false);
    }

    private void Upgrade()
    {
        GameManager_3.instance.OnPay(-(currentUpgradeInfo.cost));
        foodCostIncreasment = currentUpgradeInfo.foodCostIncreasment;
        waitTimeFactor = currentUpgradeInfo.WaitTimeFactor;
        level++;
        
    }
}


[Serializable]
public class UpgradeInfo_3
{
    [SerializeField] public int cost;
    [SerializeField] public int level;
    [SerializeField] public int foodCostIncreasment;
    [SerializeField] public float WaitTimeFactor;

    public UpgradeInfo_3(int cost, int level)
    {
        this.cost = cost;
        this.level = level;
    }
}
