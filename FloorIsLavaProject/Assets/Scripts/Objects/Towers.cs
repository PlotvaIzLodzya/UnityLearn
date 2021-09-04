using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    private UtilityScripts _utility;
    [SerializeField] AnimationCurve _animation;
    [SerializeField] float _duration;
    [SerializeField] float _maxHight;

    // Start is called before the first frame update
    void Start()
    {
        _utility = GetComponent<UtilityScripts>();
        _animation.preWrapMode = WrapMode.PingPong;
        _animation.postWrapMode = WrapMode.PingPong;


    }

        // Update is called once per frame
        void Update()
    {
        _utility.Levitation(_animation, _duration, _maxHight);
    }
}
