using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction<int,int> HealthChanged;
    public event UnityAction HealthRanOut;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void DecreaseHealth(int value)
    {
        _currentHealth -= value;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            HealthRanOut?.Invoke();
    }

    public void IncreaseHealth(int value)
    {
        if (_currentHealth + value <= _maxHealth)
            _currentHealth += value;
        else
            _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
