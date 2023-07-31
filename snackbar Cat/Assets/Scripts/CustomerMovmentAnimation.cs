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
    const string IDLE = "IDLE";
    const string DOWN = "Forward";
    const string UP = "Back";


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
