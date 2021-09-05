using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float AnimationCalculator(AnimationCurve _animCurve, float _duration, float _distance)
    {
        return _animCurve.Evaluate(Time.time / _duration) * _distance;
    }

    public void MovingForwardInWorld(float _speed)
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);
    }

    public void Levitation(AnimationCurve _animation,Vector3 _initialPos, float _duration, float _distance)
    {
        transform.position = new Vector3(transform.position.x, _initialPos.y + AnimationCalculator(_animation, _duration, _distance), transform.position.z);
    }
}

