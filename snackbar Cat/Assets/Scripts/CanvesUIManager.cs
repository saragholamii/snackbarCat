using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvesUIManager : MonoBehaviour
{


    public void AcceptUpgradeButton()
    {
        switch(Datas.GetLevel())
        {
            case 1:
                Datas.SetNewPrice(2);
                Datas.DecreaseScore(5);
                Datas.SetLevel(2);
                break;
            
            case 2:
                Datas.SetNewPrice(3);
                Datas.DecreaseScore(7);
                Datas.SetLevel(3);
                break;

            case 3:
                Datas.SetNewPrice(5);
                Datas.DecreaseScore(10);
                Datas.SetLevel(4);
                break;
            
            case 4:
                Datas.SetNewPrice(10);
                Datas.DecreaseScore(30);
                Datas.SetLevel(5);
                Upgrades.createCoffeeMaker();
                break;

            case 5:
                Datas.SetNewPrice(12);
                Datas.DecreaseScore(35);
                Datas.SetLevel(6);
                break;

            case 6:
                Datas.SetNewPrice(15);
                Datas.DecreaseScore(40);
                Datas.SetLevel(7);
                break;

            case 7:
                Datas.SetNewPrice(17);
                Datas.DecreaseScore(45);
                Datas.SetLevel(8);
                break;

            case 8:
                Datas.SetNewPrice(20);
                Datas.DecreaseScore(50);
                Datas.SetLevel(9);
                break;

            case 9:
                Datas.SetNewPrice(30);
                Datas.DecreaseScore(125);
                Datas.SetLevel(10);
                break;

        }

        Core.hideUpgradeMessage();
    }

    public void RejectUpgradeButton()
    {
        Core.hideUpgradeMessage();
        Core.showBabyUpgradeButton();
    }

    public void AcceptHelp()
    {
        Core.newSeller(1);
        Core.hideHelpUpgradeMessage();
    }

    public void RejectHelp()
    {
        Core.hideHelpUpgradeMessage();
    }
}
