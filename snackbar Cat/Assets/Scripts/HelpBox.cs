using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBox : MonoBehaviour
{
    private void OnMouseDown() 
    {
        Core.newSeller(this.gameObject.transform.position, 1);
        Destroy(this.gameObject);
    }
}
