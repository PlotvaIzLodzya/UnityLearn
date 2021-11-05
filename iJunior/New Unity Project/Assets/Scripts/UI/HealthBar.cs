using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private Health _playerHealth;

    private void OnEnable()
    {
        _playerHealth = _player.GetComponent<Health>();
        _playerHealth.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnValueChanged;
    }
}
