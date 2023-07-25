using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBox : MonoBehaviour
{
    private void OnMouseEnter() 
    {
        Core.showHelpUpgradeMessage("cost: 200 - you will get a help");
        Destroy(this.gameObject);
    }
}
