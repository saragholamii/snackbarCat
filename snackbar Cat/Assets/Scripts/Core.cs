using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Core : MonoBehaviour
{

    private float passedTime = 0f;
    [SerializeField]    private float instantiationTime = 2f;
    [SerializeField]    private Transform entryDoor;
    [SerializeField]    private Transform exitDoor;
    [SerializeField]    private TextMeshProUGUI scoreText;
    [SerializeField]    private TextMeshProUGUI levelText;
    [SerializeField]    private TextMeshProUGUI PriceText;
    [SerializeField]    private GameObject sellerPrefab;
    [SerializeField]    private Transform sellerPos;
    [SerializeField]    private GameObject helpPrefab;
    [SerializeField]    private Transform helpPos;
    [SerializeField]    private GameObject coinPrefab;
    [SerializeField]    private GameObject upgradeMessage;
    [SerializeField]    private TextMeshProUGUI upgradeMessageText;
    [SerializeField]    private GameObject babyUpgradeButton;
    [SerializeField]    private GameObject helpMessage;
    [SerializeField]    private TextMeshProUGUI helpupgradeMessageText;
    private Datas datas;
    public delegate void NewCustomer(GameObject customer);
    public static NewCustomer newCustomer;
    public delegate void ReleaseTable(GameObject table, GameObject coin);
    public static ReleaseTable releaseTable;
    public delegate void IncreaseScore(int amount);
    public static IncreaseScore increaseScore;
    public delegate void UpdateNumbers(int amount);
    public static UpdateNumbers updateScore;
    public static UpdateNumbers updateLevel;
    public static UpdateNumbers updatePrice;
    public delegate void NewSeller(int sellerNum);
    public static NewSeller newSeller;
    public delegate void UpgradeMessage(string message);
    public static UpgradeMessage showUpgradeMessage;
    public static UpgradeMessage showHelpUpgradeMessage;
    public delegate void Upgrade();
    public static Upgrade hideUpgradeMessage;
    public static Upgrade hideHelpUpgradeMessage;
    public static Upgrade showBabyUpgradeButton;
    public static Upgrade hideBabyUpgradeButton;
    

    void Start() 
    {
        datas = GetComponent<Datas>();
        scoreText.text = Datas.GetScore().ToString();
        newCustomer += AddCustomerToSellerList;
        releaseTable += Release_Table;
        increaseScore += Increase_Score;
        updateScore += Update_Score;
        updateLevel += Update_Level;
        updatePrice += Update_Price;
        newSeller += New_Seller;
        showUpgradeMessage += Show_UpgradeMessage;
        hideUpgradeMessage += Hide_UpgradeMessage;
        showBabyUpgradeButton += Show_BabyUpgradeButton;
        hideBabyUpgradeButton += Hide_BabyUpgradeButton;
        showHelpUpgradeMessage += Show_HelpUpgradeMessage;
        hideHelpUpgradeMessage += Hide_HelpUpgradeMessage;

        //create seller
        New_Seller(0);
    }

    void Update()
    {
        passedTime += Time.deltaTime;
        if(passedTime >= instantiationTime)
        {
            CreateCustomer();
            passedTime = 0f;
        }
    }

    private void CreateCustomer()
    {
        if(datas.IsThereEmptyTable())
        {
            GameObject table = datas.LocationOfEmptyTable();
            Vector3 locationOfTable = table.transform.position;
            GameObject customer =  Instantiate(datas.GetRandomCustomerPrefab(), entryDoor.position, Quaternion.identity);
            GameObject order = datas.GetRandomOrderPrefab();
            customer.GetComponent<CustomerMovement>().SetTablePos(locationOfTable);
            customer.GetComponent<CustomerMovement>().SetDoorPos(exitDoor.position);
            customer.GetComponent<Customer>().SetTable(table);
            customer.GetComponent<Customer>().SetOrderPrefab(order);
            customer.GetComponent<Customer>().SetCoin(coinPrefab);
           
        }
    }

    private void AddCustomerToSellerList(GameObject customer)
    {
        GameObject seller = datas.GetSeller();
        seller.GetComponent<Seller>().AddCustomer(customer.GetComponent<Customer>());
    }

    private void Release_Table(GameObject table, GameObject coin)
    {
        Instantiate(coin, new Vector3(table.transform.position.x, table.transform.position.y - 1, table.transform.position.z), Quaternion.identity);
        table.GetComponent<Tables>().SetEmpty();
    }

    private void Increase_Score(int amount)
    {
        Datas.IncreaseScore(amount);
        scoreText.text = Datas.GetScore().ToString();
    }

    private void Update_Score(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    private void Update_Level(int newLevel)
    {
        levelText.text = "level" + newLevel.ToString();
    }

    private void Update_Price(int newPrice)
    {
        PriceText.text = "price: " + newPrice.ToString();
    }

    private void New_Seller(int sellerNum)
    {
        GameObject newSeller;

        if(sellerNum == 0)      newSeller = Instantiate(sellerPrefab, sellerPos.position, Quaternion.identity);
        else                    newSeller = Instantiate(helpPrefab, helpPos.position, Quaternion.identity);
            
        newSeller.GetComponent<Seller>().SetKitchenTablePos(datas.GetKitchenTablePos(sellerNum));
        datas.AddNewSeller(newSeller);
    }

    private void Show_UpgradeMessage(string message)
    {
        upgradeMessageText.text = message;
        upgradeMessage.SetActive(true);
    }

    private void Hide_UpgradeMessage()
    {
        upgradeMessage.SetActive(false);
    }

    private void Show_BabyUpgradeButton()
    {
        babyUpgradeButton.SetActive(true);
    }

    private void Hide_BabyUpgradeButton()
    {
        babyUpgradeButton.SetActive(false);
    }

    private void Show_HelpUpgradeMessage(string message)
    {
       helpupgradeMessageText.text = message;
       helpMessage.SetActive(true);
    }

    private void Hide_HelpUpgradeMessage()
    {
        helpMessage.SetActive(false);
    }

}
