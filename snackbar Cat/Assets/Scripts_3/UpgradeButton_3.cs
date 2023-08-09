using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeButton_3 : MonoBehaviour
{
    [SerializeField] private UnityEvent onClickUpgardeButton;
    private Animator animator;
    
    //animations:
    private const String IDLE = "";
    void Start()
    {
        //animator.Play(IDLE);
    }
    private void OnMouseUpAsButton()
    {
        onClickUpgardeButton.Invoke();
    }
}
