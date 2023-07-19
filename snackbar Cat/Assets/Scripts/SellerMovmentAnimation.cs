using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerMovmentAnimation : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    private string currentState;
    private Vector3 currentPosition;
    private Vector3 previousPosition;
    


    //animation states:
    const string IDLE = "Customer1_Idle";
    const string UP = "Customer1_Back";
    const string DOWN = "Customer1_Forward";
    const string LEFT = "Customer1_Left";
    const string RIGHT = "Customer1_Right";


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        animator.Play("Idle");
    }


    void Update()
    {
        currentPosition = transform.position;

        if (currentPosition.x > previousPosition.x)
        {
        // Character is moving to the right
            ChangeAnimationState(RIGHT);
        }
        else if (currentPosition.x < previousPosition.x)
        {
        // Character is moving to the left
            ChangeAnimationState(LEFT);
        }

        if (currentPosition.y > previousPosition.y)
        {
        // Character is moving upwards
            ChangeAnimationState(UP);
        }
        else if (currentPosition.y < previousPosition.y)
        {
        // Character is moving downwards
            ChangeAnimationState(DOWN);
        }
        else 
        {
            //character is idle
            ChangeAnimationState(IDLE);
        }

        previousPosition = currentPosition;
    }


    private void ChangeAnimationState(string newState)
    {
        if(newState == currentState)    return;

        animator.Play(newState);
        currentState = newState;
    }
}
