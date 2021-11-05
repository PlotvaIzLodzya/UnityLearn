using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Health _health;

    public int Damage => _damage;

    public event UnityAction<Enemy> Dying;

    private void OnEnable()
    {
        _health = GetComponent<Health>();
        _health.HealthRanOut += Die;
    }

    private void OnDisable()
    {
        _health.HealthRanOut -= Die;
    }

    private void Die()
    {
        Dying?.Invoke(this);
        Destroy(gameObject);
    }
}
