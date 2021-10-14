using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxValue = 100f;
    private float _currentValue;

    public float MaxValue
    {
        get { return _maxValue; }
    }
    public float CurrentValue
    {
        get { return _currentValue; }
    }

    private void Start()
    {
        _currentValue = _maxValue;
    }

    public void Change(float value)
    {
        _currentValue += value;
        _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);
    }
}
