using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float waitTime = 2;

    public float GetWaitTime()
    {
        return waitTime;
    }
}
