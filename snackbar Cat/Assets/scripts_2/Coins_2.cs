using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins_2 : MonoBehaviour
{

    Animator animator;

    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("coinAnimation");
        StartCoroutine(WaitAndDestroy());
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
