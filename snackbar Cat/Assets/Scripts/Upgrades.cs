using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    
    [SerializeField] private GameObject coffeeMachineUpgradeButton;
    [SerializeField] private Transform coffeeUpgradeButtonPos;
    [SerializeField] private GameObject coffeeMakerSprite;
    [SerializeField] private Transform secoundCoffeeMakerPos;
    [SerializeField] private GameObject helpBox;
    [SerializeField] private Transform helpBoxPos;

    private bool level2 = false;
    private bool level3 = false;
    private bool level4 = false;
    private bool level5 = false;
    private bool level6 = false;
    private bool level7 = false;
    private bool level8 = false;
    private bool level9 = false;
    private bool level10 = false;
    private bool helpLevel = false;

    private int level = 1;
    private int score = 0;
    private int sandwitchMakerNum = 1;
    public delegate void CreateCoffeeMaker();
    public static CreateCoffeeMaker createCoffeeMaker;

    void Start()
    {
        createCoffeeMaker += Create_CoffeeMaker;
    }

    void Update()
    {
        level = Datas.GetLevel();
        score = Datas.GetScore();
        if( level == 1 && score >= 5 &&   !level2)
        {
            UpgradeLevel();
            level2 = true;
        }        
        else if( level == 2 && score >= 7 &&   !level3)
        {
            UpgradeLevel();
            level3 = true;
        }        
        else if( level == 3 && score >= 10 &&  !level4)
        {
            UpgradeLevel();
            level4 = true;
        }        
        else if( level == 4 && score >= 30 &&  !level5)
        {
            UpgradeLevel();
            level5 = true;
        }        
        else if( level == 5 && score >= 35 &&  !level6)
        {
            UpgradeLevel();
            level6 = true;
        }        
        else if( level == 6 && score >= 40 &&  !level7)
        {
            UpgradeLevel();
            level7 = true;
        }        
        else if( level == 7 && score >= 45 &&  !level8)
        {
            UpgradeLevel();
            level8 = true;
        }        
        else if( level == 8 && score >= 50 &&  !level9)
        {
            UpgradeLevel(); 
            level9 = true;
        }        
        else if( level == 9 && score >= 125 && !level10)
        {
            UpgradeLevel();
            level10 = true;
        }    

        if(level >= 5 && score >= 200 && !helpLevel)    
        {
            UpgradeHelp();
            helpLevel = true;
        }
    }


    private void UpgradeLevel()
    {
        Instantiate(coffeeMachineUpgradeButton, coffeeUpgradeButtonPos.position, Quaternion.identity);
    }

    private void Create_CoffeeMaker()
    {
        Instantiate(coffeeMakerSprite, secoundCoffeeMakerPos.position, Quaternion.identity);
        // ************* make it usable for sellers
    }

    private void UpgradeHelp()
    {
        Instantiate(helpBox, helpBoxPos.position, Quaternion.identity);
    }

    
}
