using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Health : MonoBehaviour
{
    private event Action _changed;
    private float _maxValue = 100f;
    private float _currentValue;

    public event Action Changed
    {
        add => _changed += value;
        remove => _changed -= value;
    }

    public float MaxValue => _maxValue;
    public float CurrentValue => _currentValue;

    private void Start()
    {
        _currentValue = _maxValue;
    }
        
    public void Change(float value)
    {
        _currentValue += value;
        _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);
        _changed?.Invoke();
    }
}
