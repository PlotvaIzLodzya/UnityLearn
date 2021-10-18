using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _healthBar;
    private float _smoothing = 10f;
    private Health _playerHealth;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _playerHealth = _player.GetComponent<Health>();
        _playerHealth.Changed += StartChangeCoroutine;
        _healthBar.maxValue = _playerHealth.MaxValue;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= StartChangeCoroutine;
    }

    private IEnumerator ChangeValue()
    {
        while(_healthBar.value != _playerHealth.CurrentValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _playerHealth.CurrentValue, _smoothing * Time.deltaTime);
        
            yield return null;
        }
    }

    private void StartChangeCoroutine()
    {
         StartCoroutine(ChangeValue());
    }
}
