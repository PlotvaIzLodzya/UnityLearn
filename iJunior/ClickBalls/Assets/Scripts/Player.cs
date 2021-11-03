using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _score;
    private int _currentHealth;

    public int Score => _score;

    public event UnityAction Died;
    public event UnityAction<int,int> HealthChanged;
    public event UnityAction<int> PointsChanged;

    private void Start()
    {
        PointsChanged?.Invoke(_score);
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
            _maxHealth = 0;
        }
    }

    public void AddPoint(int point)
    {
        _score += point;
        PointsChanged?.Invoke(_score);
    }
}
