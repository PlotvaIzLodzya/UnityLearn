using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private GameObject _pathPoint;
    [SerializeField] private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
        transform.DOMove(_pathPoint.transform.position, 4).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ResetPosition();
        }
    }
}
