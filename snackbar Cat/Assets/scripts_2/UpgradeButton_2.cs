using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeButton_2 : MonoBehaviour
{
    Animator animator;
    [SerializeField] private UnityEvent clickUpgradeButton;
    const string IDLE = "UpgradeButtonAnimation";

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.Play(IDLE);
    }

    private void OnMouseUp() 
    {
        clickUpgradeButton?.Invoke();
        gameObject.SetActive(false);
    }
}
