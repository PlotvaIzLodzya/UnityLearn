using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingSun : MonoBehaviour
{
    [SerializeField] Light _lightSource;
    [SerializeField] ParticleSystem _sunParticles;
    [SerializeField] AnimationCurve _lightIntensity;
    [SerializeField] UtilityScripts _utility;
    [SerializeField] float _maxIntensity=50;
    [SerializeField] float _duration = 2;


    // Start is called before the first frame update
    void Start()
    {
        _lightIntensity.preWrapMode = WrapMode.PingPong;
        _lightIntensity.postWrapMode = WrapMode.PingPong;
    }

    // Update is called once per frame
    void Update()
    {
        _lightSource.intensity = _utility.AnimationCalculator(_lightIntensity, _duration, _maxIntensity);
        if (_lightSource.intensity >= _maxIntensity)
        {
            _sunParticles.Play();
        }
    }
}
