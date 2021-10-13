using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float _duration = 0.7f;

    public IEnumerator Change(float changeValue)
    {
        float newSliderValue = _slider.value + changeValue;

        for (float timePassed = 0; timePassed < _duration; timePassed += Time.deltaTime)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, newSliderValue, timePassed / _duration);
            yield return null;
        }
    }
}
