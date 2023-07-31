using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerMovmentAnimation : MonoBehaviour
{

    Animator animator;
    private string currentState;
    private Vector3 currentPosition;
    private Vector3 previousPosition;
    


    //animation states:
    const string IDLE = "IDLE";
    const string UP = "Back";
    const string DOWN = "Forward";
    const string LEFT = "Seller_RunLeft";
    const string RIGHT = "Seller_RunRight";


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.Play(IDLE);
    }


    void Update()
    {
        currentPosition = transform.position;

        if(Vector3.Distance(currentPosition, previousPosition) <= 0.01f)        ChangeAnimationState(IDLE);
        else  if(currentPosition.y <= previousPosition.y)                        ChangeAnimationState(DOWN);
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
