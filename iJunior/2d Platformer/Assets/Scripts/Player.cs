using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coinCounter = 0;

    private void CollectCoin()
    {
        _coinCounter++;
        Debug.Log($"Монеток собрано: {_coinCounter}");
    }

    public void ResetPosition()
    {
        transform.position = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            CollectCoin();
        }
    }
}
