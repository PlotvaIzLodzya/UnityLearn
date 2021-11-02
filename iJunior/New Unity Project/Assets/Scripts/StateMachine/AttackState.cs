using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Enemy))]
public class AttackState : State
{
    [SerializeField] private float _delay;

    private int _damage;
    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _damage = GetComponent<Enemy>().Damage;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play("Attack");

        if(target != null)
            target.ApplyDamage(_damage);
    }
}
