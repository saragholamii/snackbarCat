using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject helpBox;
    [SerializeField] private GameObject upgradeMessage;
    [SerializeField] private TextMeshProUGUI upgradeMessageText;
    [SerializeField] private GameObject upgradeHelpMessage;
    [SerializeField] private TextMeshProUGUI upgradeHelpMessageText;
    [SerializeField] private GameObject helpPrefab;


    [SerializeField] private List<LevelInfo> upgradePrices;
    [SerializeField] private List<AssistantInfo> assistantInfos;

    [SerializeField] private int coins;
    private int level = 1;
    private LevelInfo currentlevelInfo
    {
        get
        {
            if (level >= upgradePrices.Count)
            {
                return new LevelInfo(int.MaxValue,100);
            }

            return upgradePrices[level - 1];
        }
    }


    //upgrade bools:
    private bool isUpgradable;


    void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/savaData.jason"))
        {
            string jason = File.ReadAllText(Application.persistentDataPath + "/savaData.jason");
            SavaData savaData = JsonUtility.FromJson<SavaData>(jason);
            coins = int.Parse(savaData.score);
            level = int.Parse(savaData.level);
        }
    }

    void Start()
    {
        SetScores();
    }

    //when they want to pay for thiere order
    public void onPay()
    {
        coins += currentlevelInfo.tipMoney;
        coinText.text = coins.ToString();
        CheckForUpgrade();
    }

    private void CheckForUpgrade()
    {

        if (coins >= currentlevelInfo.upgradePrice && !isUpgradable)
        {
            UpgradeLevel();
            ShowAssistantButton();
            isUpgradable = true;
        }
    }

    private void UpgradeLevel()
    {
        upgradeButton.SetActive(true);
    }

    private void ShowAssistantButton()
    {
        for (int i = 0; i < assistantInfos.Count; i++)
        {
            if (!assistantInfos[i].used && level >= assistantInfos[i].level)
            {
                UpgradeHelp();
                return;
            }
        }
    }

    private void UpgradeHelp()
    {
        helpBox.SetActive(true);
    }

    public void ClickUpgradeButton()
    {
        SetMessageText();
        upgradeMessage.SetActive(true);
    }

    //if player accepts the upgrade - call by accept button
    public void OnAcceptUpgrade()
    {


        if (coins >= currentlevelInfo.upgradePrice)
        {
            level++;
            coins -= currentlevelInfo.upgradePrice;
            upgradeMessage.SetActive(false);
            SetScores();
            isUpgradable = false;
        }


    }

    //if player reject upgrade - call by rejct button
    public void OnRejectUpgrade()
    {
        upgradeMessage.SetActive(false);
        isUpgradable = false;
    }


    private void SetScores()
    {
        coinText.text = coins.ToString();
        levelText.text = "level " + level.ToString();
        priceText.text = "tip price " + currentlevelInfo.tipMoney.ToString();
    }

    //Upgrade Help Methods: 
    //on click helpBox
    public void OnClickHelpBox()
    {
        upgradeHelpMessageText.text = "a help will join you for 200 coins";
        upgradeHelpMessage.SetActive(true);
    }


    //on accept help upgrade - call by a button
    public void OnAcceptHelp()
    {
        upgradeHelpMessage.SetActive(false);
        coins -= 200;
        Instantiate(helpPrefab, helpBox.transform.position, Quaternion.identity);
    }

    //on reject help upgrade - call by a button
    public void OnRejectHelp()
    {
        upgradeHelpMessage.SetActive(false);
    }


    private void SetMessageText()
    {
        string message = "";

        message = $" cost: {currentlevelInfo.upgradePrice}, tip price: {currentlevelInfo.tipMoney}";

        upgradeMessageText.text = message;
    }

    public void OnQuit()
    {
        SavaData saveData = new SavaData(coins.ToString(), level.ToString(), currentlevelInfo.tipMoney.ToString());
        string jason = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savaData.jason", jason);
        Application.Quit();
    }

}

[Serializable]
public class AssistantInfo
{
    [SerializeField]
    public bool used = false;
    [SerializeField]
    public int level;
}

[Serializable]
public class LevelInfo
{
    [SerializeField]
    public int upgradePrice;
    [SerializeField]
    public int tipMoney;

    public LevelInfo(int upgradePrice, int tipMoney)
    {
        this.tipMoney = tipMoney;
        this.upgradePrice = upgradePrice;
    }
}
