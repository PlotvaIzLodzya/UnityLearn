using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private int _rewardPoints;

    private Player _player;

    public event UnityAction<int> Poped;

    public void Init(Player player)
    {
        _player = player;
        Poped += _player.AddPoint;
    }

    public void Pop()
    {
        Poped?.Invoke(_rewardPoints);
        Poped -= _player.AddPoint;
        Destroy(gameObject);
    }
}
