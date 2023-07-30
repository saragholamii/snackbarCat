using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeHelp : MonoBehaviour
{
    [SerializeField] private UnityEvent clickUpgradeHelp;

    private void OnMouseUp() 
    {
        clickUpgradeHelp?.Invoke();
        gameObject.SetActive(false);
    }
}
