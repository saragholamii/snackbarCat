using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

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
    
    private int coins;
    private int level = 1;
    private int price = 1;


    //upgrade bools:
    private bool level2 = false, level3 = false, level4 = false,level5 = false, level6 = false, 
    level7 = false, level8 = false, level9 = false, level10 = false, helpLevel = false;
    

    void Awake()
    {
        if(File.Exists(Application.persistentDataPath + "/savaData.jason"))
        {
            string jason = File.ReadAllText(Application.persistentDataPath + "/savaData.jason");
            SavaData savaData = JsonUtility.FromJson<SavaData>(jason);
            coins = int.Parse(savaData.score);
            price = int.Parse(savaData.price);
            level = int.Parse(savaData.level);
        }
    }

    void Start()
    {
        SetScores();
    }

    public void onPay()
    {
        coins += price;
        coinText.text = coins.ToString();
        CheckForUpgrade();
    }

    private void CheckForUpgrade()
    {
        if( level == 1 && coins >= 5 &&   !level2)
        {
            UpgradeLevel();
            level2 = true;
        }        
        else if( level == 2 && coins >= 7 &&   !level3)
        {
            UpgradeLevel();
            level3 = true;
        }        
        else if( level == 3 && coins >= 10 &&  !level4)
        {
            UpgradeLevel();
            level4 = true;
        }        
        else if( level == 4 && coins >= 30 &&  !level5)
        {
            UpgradeLevel();
            level5 = true;
        }        
        else if( level == 5 && coins >= 35 &&  !level6)
        {
            UpgradeLevel();
            level6 = true;
        }        
        else if( level == 6 && coins >= 40 &&  !level7)
        {
            UpgradeLevel();
            level7 = true;
        }        
        else if( level == 7 && coins >= 45 &&  !level8)
        {
            UpgradeLevel();
            level8 = true;
        }        
        else if( level == 8 && coins >= 50 &&  !level9)
        {
            UpgradeLevel(); 
            level9 = true;
        }        
        else if( level == 9 && coins >= 125 && !level10)
        {
            UpgradeLevel();
            level10 = true;
        }    

        if(level >= 5 && coins >= 200 && !helpLevel)    
        {
            UpgradeHelp();
            helpLevel = true;
        }
    }

    private void UpgradeLevel()
    {
        upgradeButton.SetActive(true);
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
        switch(level)
        {
            case 1:
                price = 2;
                level = 2;
                coins -=5;
                break;
            case 2:
                price = 3;
                level = 3;
                coins -=7;
                break;
            case 3:
                price = 5;
                level = 4;
                coins -= 10;
                break;
            case 4:
                price = 10;
                level = 5;
                coins -=30;
                break;
            case 5:
                price = 12;
                level = 6;
                coins -= 35;
                break;
            case 6:
                price = 15;
                level = 7;
                coins -= 40;
                break;
            case 7:
                price = 17;
                level = 8;
                coins -= 45;
                break;
            case 8:
                price = 20;
                level = 9;
                coins -= 50;
                break;
            case 9:
                price = 30;
                level = 10;
                coins -= 125;
                break;
        }

        upgradeMessage.SetActive(false);
        SetScores();
    }

    //if player reject upgrade - call by rejct button
    public void OnRejectUpgrade()
    {
        upgradeMessage.SetActive(false);
    }


    private void SetScores()
    {
        coinText.text = coins.ToString();
        levelText.text = "level " + level.ToString();
        priceText.text = "price " + price.ToString();
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
        switch(level)
        {
            case 1:
                message = " cost: 5 - price: 2";
                break;
            case 2:
                message = " cost: 7 - price: 3";
                break;
            case 3:
                message = " cost: 10 - price: 5";
                break;
            case 4:
                message = " cost: 30 - price: 10 and a new cattle";
                break;
            case 5:
                message = " cost: 35 - price: 12";
                break;
            case 6:
                message = " cost: 40 - price: 15";
                break;
            case 7:
                message = " cost: 45 - price: 17";
                break;
            case 8:
                message = " cost: 50 - price: 20";
                break;
            case 9:
                message = " cost: 30 - price: 125";
                break;
        }

        upgradeMessageText.text = message;
    }

    public void OnQuit()
    {
        SavaData saveData = new SavaData(coins.ToString(), level.ToString(), price.ToString());
        string jason = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savaData.jason", jason);
        Application.Quit();
    }
}
