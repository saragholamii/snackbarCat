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
    [SerializeField]    private Transform doorPos;
    [SerializeField]    private GameObject customerPrefab;
    [SerializeField]    private TextMeshProUGUI scoreText;
    [SerializeField]    private TextMeshProUGUI levelText;
    [SerializeField]    private TextMeshProUGUI PriceText;
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
            GameObject customer =  Instantiate(customerPrefab, doorPos.position, Quaternion.identity);
            GameObject[] order = datas.GetRandomOrderPrefab();
            customer.GetComponent<CustomerMovement>().SetTablePos(locationOfTable);
            customer.GetComponent<CustomerMovement>().SetDoorPos(doorPos.position);
            customer.GetComponent<Customer>().SetTable(table);
            customer.GetComponent<Customer>().SetOrderPrefab(order[0]);
            customer.GetComponent<Customer>().SetCoin(order[1]);
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
}
