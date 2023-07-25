using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovmentAnimation : MonoBehaviour
{

    Animator animator;
    private string currentState;
    private Vector3 currentPosition;
    private Vector3 previousPosition;


    //animation states:
    const string IDLE = "Customer1_Idle";
    const string DOWN = "Customer1_Forward";
    const string UP = "Customer1_Back";


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.Play(DOWN);
    }

    
    void Update()
    {
        currentPosition = transform.position;
        if(Vector3.Distance(currentPosition, previousPosition) <= 0.01f)        ChangeAnimationState(IDLE);
        else  if(currentPosition.y < previousPosition.y)                        ChangeAnimationState(DOWN);
        else                                                                    ChangeAnimationState(UP);
        previousPosition = currentPosition;

    }

    private void ChangeAnimationState(string newState)
    {
        if(newState == currentState)    return;

        animator.Play(newState);
        currentState = newState;
    }
}
