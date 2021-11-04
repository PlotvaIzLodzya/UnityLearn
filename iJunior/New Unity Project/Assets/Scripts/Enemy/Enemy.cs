using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;

    private int _currentHealth;
    private Player _target;
    private Rigidbody2D _rigidbody2D;

    public int Damage => _damage;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentHealth = _maxHealth;
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    public void AddForce(Vector3 direction, float force)
    {
        _rigidbody2D.AddForce(direction * force);
    }

    private void Die()
    {
        Dying?.Invoke(this);
        Destroy(gameObject);
    }
}
