using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    [SerializeField] private int coinDestroyTime = 2;
    Animator animator;
    const string IDLE = "coinAnimation";

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(IDLE);
        StartCoroutine(DestroyCoin());
    }

    private IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(coinDestroyTime);
        Core.increaseScore(Datas.GetPrice());
        Destroy(this.gameObject);
    }
}
