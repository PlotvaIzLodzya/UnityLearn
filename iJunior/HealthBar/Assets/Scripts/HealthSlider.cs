using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]

public class HealthSlider : MonoBehaviour
{
    private Slider _healthBar;
    private float _smoothing = 10f;
    [SerializeField] private Player _player;

    private Health _playerHealth => _player.GetComponent<Health>();

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _playerHealth.MaxValue;
    }

    private void Update()
    {
        if (_healthBar.value != _playerHealth.CurrentValue)
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _playerHealth.CurrentValue, _smoothing * Time.deltaTime);
    }
}
