using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxValue = 100f;
    private float _currentValue;
    private float _duration = 0.7f;

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

    public IEnumerator Change(float changeValue)
    {
        float newValue = CurrentValue + changeValue;

        for (float timePassed = 0; timePassed < _duration; timePassed += Time.deltaTime)
        {
            _currentValue = Mathf.MoveTowards(CurrentValue, newValue, timePassed / _duration);
            yield return null;
        }

        _currentValue = Mathf.Clamp(CurrentValue, 0f, _maxValue);
    }
}
