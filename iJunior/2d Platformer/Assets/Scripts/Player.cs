using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coinCounter = 0;
    
    public void CollectCoin()
    {
        _coinCounter++;
        Debug.Log($"Монеток собрано: {_coinCounter}");
    }

    public void ResetPosition()
    {
        transform.position = Vector2.zero;
    }
}
