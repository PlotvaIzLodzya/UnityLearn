using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MovingCalculator
{
    [SerializeField] AnimationCurve _animation;
    [SerializeField] float _duration;
    [SerializeField] float _distance;
    private Vector3 _initialPos;

    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.position;
        _animation.preWrapMode = WrapMode.PingPong;
        _animation.postWrapMode = WrapMode.PingPong;
    }

        // Update is called once per frame
        void Update()
    {
        Levitation(_animation, _initialPos, _duration, _distance);
    }
}
