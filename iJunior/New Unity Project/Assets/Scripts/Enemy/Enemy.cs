using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;

    private Animator _animator;
    private SpriteRenderer _renderer;
    private int _currentHealth;
    private Player _target;

    public int Damage => _damage;
    public Player Target => _target;
    private bool IsFacingRight => transform.position.x < _target.transform.position.x;

    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        _renderer.flipX = IsFacingRight;
    }

    public void Init(Player target)
    {
        _target = target;
    }

    private void OnEnable()
    {
        
    }

    public void ApplyDamage(int damage)
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
