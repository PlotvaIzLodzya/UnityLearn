using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private Player _player;

    private float _maxHealth => _player.Health.MaxValue;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _maxHealth;
    }

    private void Update()
    {
        _slider.value = _player.Health.CurrentValue;
    }
}
