using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    private Slider _healthBar;
    private float _smoothing = 10f;
    [SerializeField] private Player _player;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.maxValue = _player.Health.MaxValue;
    }

    private void Update()
    {
        if (_player.Health.CurrentValue != _healthBar.value)
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health.CurrentValue, _smoothing * Time.deltaTime);
    }
}
