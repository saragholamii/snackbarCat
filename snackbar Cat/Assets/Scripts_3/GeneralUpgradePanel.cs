using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUpgradePanel : MonoBehaviour
{
    [SerializeField] private List<GeneralUpgrade_Info> generalUpgradeInfos = new List<GeneralUpgrade_Info>();
    
    private void Start()
    {
        GameObject option_template = transform.GetChild(0).gameObject;
        GameObject nextOption;
        for (int i = 0; i < generalUpgradeInfos.Count; i++)
        {
            nextOption = Instantiate(option_template, transform);
            nextOption.GetComponentInChildren<TMP_Text>().text = generalUpgradeInfos[i].description + $"for {generalUpgradeInfos[i].cost} coin";
            nextOption.GetComponentInChildren<Image>().sprite = generalUpgradeInfos[i].image;
            nextOption.GetComponentInChildren<Button>().GetComponent<GeneralUpgradeBuyButton>().SetCost(generalUpgradeInfos[i].cost);
        }
        
        Destroy(option_template);
    }
}


[Serializable]
public class GeneralUpgrade_Info
{
    [SerializeField] public Sprite image;
    [SerializeField] public string description;
    [SerializeField] public int cost;
}
