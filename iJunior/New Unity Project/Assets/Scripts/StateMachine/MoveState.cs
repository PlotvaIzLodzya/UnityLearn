using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private SpriteRenderer _renderer;
    private bool IsFacingRight => transform.position.x < Target.transform.position.x;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _renderer.flipX = IsFacingRight;
        _animator.Play("Moving");
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}
