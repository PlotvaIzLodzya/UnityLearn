using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float Speed;
    public ParticleSystem FlameEffect;

    private Slider _slider;
    private float _value;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _value = _slider.value;
    }

    void Update()
    {
        if (_slider.value != _value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _value, Speed * Time.deltaTime);
            if (_slider.value > _value)
                FlameEffect.Play();
        }
        else
        {
            FlameEffect.Stop();
        }
    }

    public void OnEndEdit(string str)
    {
        _value = float.Parse(str);
    }
}
