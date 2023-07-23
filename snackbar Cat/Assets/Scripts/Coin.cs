using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    [SerializeField] private int coinDestroyTime = 2;
    [SerializeField] private int coinValue = 1;
    private Animation animation;
    void Start()
    {
        animation = GetComponent<Animation>();
        animation.Play();
        StartCoroutine(DestroyCoin());
    }

    private IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(coinDestroyTime);
        Core.increaseScore(coinValue);
        Destroy(this.gameObject);
    }
}
