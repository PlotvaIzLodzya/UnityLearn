using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    private Slider _healthBar;
    private float _smoothing = 10f;
    [SerializeField] private Player _player;

    private float _currentValue => _player.Health.CurrentValue;
    private float _maxHealth => _player.Health.MaxValue;
    private bool _isEqual => _currentValue == _healthBar.value;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _maxHealth;
    }

    private void Update()
    {
        if (_isEqual == false)
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentValue, _smoothing * Time.deltaTime);
    }
}
