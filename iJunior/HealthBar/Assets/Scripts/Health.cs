using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    private float _duration = 0.7f;

    public IEnumerator Change(float changeValue)
    {
        float newSliderValue = Slider.value + changeValue;

        for (float timePassed = 0; timePassed < _duration; timePassed += Time.deltaTime)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, newSliderValue, timePassed / _duration);
            yield return null;
        }
    }
}
