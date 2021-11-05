using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AttackState : State
{
    [SerializeField] private float _delay;

    private int _damage;
    private float _lastAttackTime =0;

    private void Start()
    {
        _damage = GetComponent<Enemy>().Damage;
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
        _animator.Play(AnimatorEnemyController.States.Attack);

        if(target != null)
        {
            if (target.TryGetComponent(out Damagable damagable))
                damagable.TakeDamage(_damage);
        }
    }
}
