using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    Animator animator;
    const string IDLE = "UpgradeButtonAnimation";

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.Play(IDLE);
    }

    private void OnMouseUp() 
    {
        string message = "";
        switch(Datas.GetLevel())
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

        Core.showUpgradeMessage(message);
        Destroy(this.gameObject);
    }
}
