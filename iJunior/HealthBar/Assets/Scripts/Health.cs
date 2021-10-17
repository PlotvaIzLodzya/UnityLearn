using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private float _maxValue = 100f;
    [SerializeField] private float _currentValue;
    [SerializeField] private UnityEvent _ñhanged;

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
        _ñhanged.Invoke();
    }
}
