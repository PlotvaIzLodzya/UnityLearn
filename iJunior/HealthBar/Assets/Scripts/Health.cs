using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent _ñhanged;

    private float _maxValue = 100f;
    private float _currentValue;

    public float MaxValue => _maxValue;
    public float CurrentValue => _currentValue;

    public event UnityAction Changed
    {
        add => _ñhanged.AddListener(value);
        remove => _ñhanged.RemoveListener(value);
    }

    public void Change(float value)
    {
        _currentValue += value;
        _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);
        _ñhanged?.Invoke();
    }

    private void Start()
    {
        _currentValue = _maxValue;
    }
}
