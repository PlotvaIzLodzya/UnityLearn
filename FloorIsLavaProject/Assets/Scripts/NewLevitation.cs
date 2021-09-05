using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevitation : MonoBehaviour
{
    private UtilityScripts _utility;
    [SerializeField] AnimationCurve _animation;
    [SerializeField] float _duration;
    [SerializeField] float _distance;

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
        transform.position = new Vector3(transform.position.z, transform.position.y + _utility.AnimationCalculator(_animation, _duration, _distance), transform.position.z);
    }
}
