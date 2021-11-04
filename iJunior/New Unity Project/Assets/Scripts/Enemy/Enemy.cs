using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;

    private int _currentHealth;
    private Player _target;

    public int Damage => _damage;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Dying?.Invoke(this);
        Destroy(gameObject);
    }
}
