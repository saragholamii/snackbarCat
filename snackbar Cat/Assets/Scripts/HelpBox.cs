using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBox : MonoBehaviour
{
    private void OnMouseUp() 
    {
        Core.showHelpUpgradeMessage("cost: 200 - you will get a help");
        Destroy(this.gameObject);
    }

    
}
