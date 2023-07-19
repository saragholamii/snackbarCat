using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tables : MonoBehaviour
{
    [HideInInspector]
    public bool full = false;

    public void SetFull()
    {
        full = true;
    }

    public void SetEmpty()
    {
        full = false;
    }
}
